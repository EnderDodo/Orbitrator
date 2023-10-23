using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Orb : ScriptableObject
{
    public int priority;
    public int baseDamage;
    public float baseSpeed;
    [SerializeField] [CanBeNull] public GameObject instantiatedObject;
    [SerializeField] [CanBeNull] private Material particleMaterial;
    [SerializeField] [CanBeNull] private GameObject pickupAnalogue;
    public int amountInCurrentSpell = 0;
    [CanBeNull] public Effect appliedEffect;
}