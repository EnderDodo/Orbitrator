using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public enum OrbType {Projectile, Spray, Laser}

public class Orb : ScriptableObject
{
    public OrbType orbType; //make read-only
    public int priority;
    public float baseDamage;
    public float baseSpeed;
    [SerializeField] [CanBeNull] private GameObject instantiatedObject;
    [SerializeField] [CanBeNull] private Material particleMaterial;
    [SerializeField] [CanBeNull] private GameObject pickupAnalogue;
    public int amountInCurrentSpell = 0;
    //public abstract void Cast(int amount, Orb[] secondaryEffects); //perhaps it should be in Spell.cs?
}

/*[CreateAssetMenu(fileName = "New Projectile Orb", menuName = "Projectile Orb")]
public class ProjectileOrb : Orb
{
    public override void Cast(int amount, Orb[] secondaryEffects)
    {
        
    }
}

[CreateAssetMenu(fileName = "New Spray Orb", menuName = "Spray Orb")]
public class SprayOrb : Orb
{
    public override void Cast(int amount, Orb[] secondaryEffects)
    {
        
    }
}*/