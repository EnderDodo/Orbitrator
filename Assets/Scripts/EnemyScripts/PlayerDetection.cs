using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private GameObject _target;

    public Action<GameObject> TargetDetected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.gameObject;
            TargetDetected?.Invoke(_target);
        }
    }
}
