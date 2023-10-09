using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Spray Orb", menuName = "Orb/Spray Orb")]
public class SprayOrb : Orb
{
    public float projectileSizeIncrease;
    public float baseMaxDistance;
    public float baseMaxCastTime;
    public float projectileGrowthPerSecondIncrease;
    public float minSpread;
    public float maxSpread;
}