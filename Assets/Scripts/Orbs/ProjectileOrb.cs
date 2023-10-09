using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Projectile Orb", menuName = "Orb/Projectile Orb")]
public class ProjectileOrb : Orb
{
    public float projectileSizeIncrease;
    public float baseMaxChargeTime;
    public float chargeSpeedAddPerSec;
    public float chargeDamageAddPerSec;
    public float explosionRadiusIncrease;
    public int explosionDamageMultiplier;
}