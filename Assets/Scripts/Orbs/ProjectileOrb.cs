using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Orb", menuName = "Orb/Projectile Orb")]
public class ProjectileOrb : Orb
{
    public float baseRadius;
    public float baseMaxChargeTime;
    public float chargeSpeedAddPerSec;
    public float chargeDamageAddPerSec;
    public float baseExplosionRadius;
    public int explosionDamageMultiplier;
}