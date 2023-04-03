using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Orb : ScriptableObject
{
    public int priority;
    public float baseDamage;
    public float baseSpeed;
    [SerializeField] [CanBeNull] private GameObject instantiatedObject;
    [SerializeField] [CanBeNull] private Material particleMaterial;
    [SerializeField] [CanBeNull] private GameObject pickupAnalogue;
    public int amountInCurrentSpell = 0;
}

[CreateAssetMenu(fileName = "New Projectile Orb", menuName = "Projectile Orb")]
public class ProjectileOrb : Orb
{
    
}

[CreateAssetMenu(fileName = "New Spray Orb", menuName = "Spray Orb")]
public class SprayOrb : Orb
{
    
}
[CreateAssetMenu(fileName = "New Laser Orb", menuName = "Laser Orb")]
public class LaserOrb : Orb
{
    
}