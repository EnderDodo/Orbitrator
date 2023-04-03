using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



public abstract class Spell
{
    public List<Orb> PrimaryOrbs; //should be made readonly?
    public List<Orb> SecondaryOrbs; //should be made readonly?
    private Vector3 _spawnPoint;

    public Spell()
    {
        
    }
    
    protected Spell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs)
    {
        PrimaryOrbs = primaryOrbs;
        SecondaryOrbs = secondaryOrbs;
    }

    public abstract Spell AddOrb(Orb orb);

    public abstract void Cast();
}

public class NullSpell : Spell
{
    public override Spell AddOrb(Orb orb)
    {
        switch (orb)
        {
            case ProjectileOrb:
                PrimaryOrbs.Add(orb);
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                PrimaryOrbs.Add(orb);
                return new SpraySpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                PrimaryOrbs.Add(orb);
                return new LaserSpell(PrimaryOrbs, SecondaryOrbs);
        }
        return this;
    }

    public override void Cast()
    {
        throw new System.NotImplementedException();
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
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                SecondaryOrbs.Add(orb);
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                SecondaryOrbs.Add(orb);
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
        }
        return this;
    }

    public override void Cast()
    {
        
    }
}

public class SpraySpell : Spell
{
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
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                PrimaryOrbs.Add(orb);
                return new SpraySpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                SecondaryOrbs.AddRange(PrimaryOrbs);
                PrimaryOrbs.Clear();
                PrimaryOrbs.Add(orb);
                return new LaserSpell(PrimaryOrbs, SecondaryOrbs);
        }
        return this;
    }
    
    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}

public class LaserSpell : Spell 
{
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
                return new ProjectileSpell(PrimaryOrbs, SecondaryOrbs);
            case SprayOrb:
                SecondaryOrbs.Add(orb);
                return new SpraySpell(PrimaryOrbs, SecondaryOrbs);
            case LaserOrb:
                PrimaryOrbs.Add(orb);
                return new LaserSpell(PrimaryOrbs, SecondaryOrbs);
        }
        return this;
    }
    
    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}