using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemOrb : MonoBehaviour
{
    [SerializeField] private Orb orb;

    public Orb GetOrb()
    {
        return orb;
    }
}
