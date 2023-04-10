using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OrbHolder : MonoBehaviour
{
    [SerializeField] [CanBeNull] public Orb orb;
    [SerializeField] public KeyCode orbKey;
}
