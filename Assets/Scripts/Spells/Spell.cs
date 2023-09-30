using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public abstract class Spell
{
    public static SpellSystem SpellSystem;
    protected List<Orb> PrimaryOrbs; //should be made readonly?
    protected List<Orb> SecondaryOrbs; //should be made readonly?
    protected Vector3 SpawnPoint;
    public event Action WasCasted;
    //public event Action OrbAdded;

    protected Spell()
    {
    }

    protected Spell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs)
    {
        PrimaryOrbs = primaryOrbs;
        SecondaryOrbs = secondaryOrbs;
    }

    public abstract Spell AddOrb(Orb orb);

    public virtual void Cast()
    {
        foreach (var orb in PrimaryOrbs)
        {
            orb.amountInCurrentSpell = 0;
        }

        foreach (var orb in SecondaryOrbs)
        {
            orb.amountInCurrentSpell = 0;
        }

        PrimaryOrbs.Clear();
        SecondaryOrbs.Clear();
        WasCasted?.Invoke();
    }
    
    // protected Vector3 FindDirection()
    // {}

    protected Orb MainOrb()
    {
        int biggestAmount = 0;
        Orb mainOrb = null;
        foreach (var orb in PrimaryOrbs)
        {
            if (orb.amountInCurrentSpell > biggestAmount) //choosing projectile of which type to instantiate
            {
                biggestAmount = orb.amountInCurrentSpell;
                mainOrb = orb;
            }
        }

        return mainOrb;
    }
}

public class NullSpell : Spell
{
    public float MaxChargeTime;

    public override Spell AddOrb(Orb orb)
    {
        PrimaryOrbs = new List<Orb>();
        SecondaryOrbs = new List<Orb>();
        switch (orb)
        {
            case ProjectileOrb:
                PrimaryOrbs.Add(orb);
                Debug.Log("Projectile Orb added!");
                orb.amountInCurrentSpell++;
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                PrimaryOrbs.Add(orb);
                Debug.Log("Spray Orb added!");
                orb.amountInCurrentSpell++;
                return new SpraySpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                PrimaryOrbs.Add(orb);
                Debug.Log("Laser Orb added!");
                orb.amountInCurrentSpell++;
                return new LaserSpell(PrimaryOrbs, SecondaryOrbs);
        }

        return this;
    }

    public override void Cast()
    {
        Debug.Log("Null Spell casted!");
        //knocks back
        //chargeable
    }
}

public class ProjectileSpell : Spell
{
    public ProjectileSpell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs) : base(primaryOrbs, secondaryOrbs)
    {
    }

    public override Spell AddOrb(Orb orb)
    {
        switch (orb)
        {
            case ProjectileOrb:
                PrimaryOrbs.Add(orb);
                //Debug.Log("Projectile Orb added!");
                orb.amountInCurrentSpell++;
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                SecondaryOrbs.Add(orb);
                orb.amountInCurrentSpell++;
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                SecondaryOrbs.Add(orb);
                orb.amountInCurrentSpell++;
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
        }

        return this;
    }

    public override void Cast()
    {
        Debug.Log("Projectile Spell is being casted!");
        
        var direction = SpellSystem.GetDirectedSpellDirection(out var playerPosition);
        SpawnPoint = SpellSystem.GetDirectedSpellSpawnPoint();
        
        var speed = 0f;
        var pDamage = 0;
        var pRadius = 0f;
        var eDamage = 0;
        var eRadius = 0f;
        foreach (ProjectileOrb orb in PrimaryOrbs)
        {
            speed += orb.baseSpeed;
            pDamage += orb.baseDamage;
            pRadius += orb.baseRadius;
            Debug.Log(pDamage);
        }

        speed /= PrimaryOrbs.Count; //to be made chargeable later

        var explosionRadiusIncrease = ((ProjectileOrb)MainOrb()).baseExplosionRadius;
        foreach (var orb in SecondaryOrbs)
        {
            eDamage += orb.baseDamage * 20;
            eRadius += explosionRadiusIncrease;
        }

        var projectile = UnityEngine.Object.Instantiate(MainOrb().instantiatedObject, SpawnPoint, Quaternion.identity);
        var stats = projectile.GetComponent<Projectile>();
        stats.direction = direction;
        stats.speed = speed;
        stats.projectileDamage = pDamage;
        stats.explosionDamage = eDamage;
        stats.explosionRadius = eRadius;

        base.Cast();
    }
}

public class SpraySpell : Spell
{
    public float MaxCastTime;

    public SpraySpell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs) : base(primaryOrbs, secondaryOrbs)
    {
    }

    public override Spell AddOrb(Orb orb)
    {
        switch (orb)
        {
            case ProjectileOrb:
                SecondaryOrbs.AddRange(PrimaryOrbs);
                PrimaryOrbs.Clear();
                PrimaryOrbs.Add(orb);
                //Debug.Log("Projectile Orb added!");
                orb.amountInCurrentSpell++;
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                PrimaryOrbs.Add(orb);
                orb.amountInCurrentSpell++;
                return new SpraySpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                SecondaryOrbs.AddRange(PrimaryOrbs);
                PrimaryOrbs.Clear();
                PrimaryOrbs.Add(orb);
                orb.amountInCurrentSpell++;
                return new LaserSpell(PrimaryOrbs, SecondaryOrbs);
        }

        return this;
    }

    public override void Cast()
    {
        Debug.Log("Spray Spell is being casted!");

        // var camera = Camera.main;
        // var cameraPosition = camera.transform.position;
        // cameraPosition.z = 0f;
        // var direction = camera.ScreenToWorldPoint(Input.mousePosition) - cameraPosition;
        // direction.z = 0f;
        // direction.Normalize();
        // SpawnPoint = cameraPosition + direction * 1.5f;
        
        var direction = SpellSystem.GetDirectedSpellDirection(out var playerPosition);
        SpawnPoint = SpellSystem.GetDirectedSpellSpawnPoint();

        float speed = 0f;
        int damage = 0;
        float maxDistance = 0f;

        foreach (SprayOrb orb in PrimaryOrbs)
        {
            MaxCastTime += orb.baseMaxCastTime;
            speed += orb.baseSpeed;
            damage += orb.baseDamage;
            maxDistance += orb.baseMaxDistance;
        }

        SpellSystem.StartCoroutine(SpawnSprayProjectiles(MainOrb().instantiatedObject, speed, damage, maxDistance));

        base.Cast();
    }

    private IEnumerator SpawnSprayProjectiles(GameObject sprayProjectile, float speed, int damage, float maxDistance)
    {
        var currTime = 0f;
        
        while (currTime <= MaxCastTime)
        {
            var direction = SpellSystem.GetDirectedSpellDirection(out var playerPosition);
            SpawnPoint = SpellSystem.GetDirectedSpellSpawnPoint();

            var spray = UnityEngine.Object.Instantiate(sprayProjectile, SpawnPoint, Quaternion.identity);
            var stats = spray.GetComponent<SprayProjectile>();
            stats.direction = direction;
            stats.speed = speed;
            stats.damage = damage;
            stats.maxDistance = maxDistance;

            currTime += Time.deltaTime;
            yield return null;
        }

        //also stop when CastKeyUp
    }
}

public class LaserSpell : Spell
{
    public float MaxCastTime;

    public LaserSpell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs) : base(primaryOrbs, secondaryOrbs)
    {
    }

    public override Spell AddOrb(Orb orb)
    {
        switch (orb)
        {
            case ProjectileOrb:
                SecondaryOrbs.AddRange(PrimaryOrbs);
                PrimaryOrbs.Clear();
                PrimaryOrbs.Add(orb);
                orb.amountInCurrentSpell++;
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                SecondaryOrbs.Add(orb);
                orb.amountInCurrentSpell++;
                return new SpraySpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                PrimaryOrbs.Add(orb);
                orb.amountInCurrentSpell++;
                return new LaserSpell(PrimaryOrbs, SecondaryOrbs);
        }

        return this;
    }

    public override void Cast()
    {
        var direction = SpellSystem.GetDirectedSpellDirection(out var playerPosition);
        SpawnPoint = SpellSystem.GetDirectedSpellSpawnPoint();

        //cast mechanics like SpraySpell, but only one laser
        //and without it's direction changing continuously for a little
        base.Cast();
    }
}