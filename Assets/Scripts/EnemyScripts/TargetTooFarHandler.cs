using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTooFarHandler : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private PlayerDetection playerDetection;

    public Action TargetTooFar;

    private void Awake()
    {
        //playerDetection = transform.parent.GetComponentInChildren<PlayerDetection>();
        playerDetection.TargetDetected += SetTarget;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (_target is null) return;
        if (other.gameObject == _target)
        {
            TargetTooFar?.Invoke();
        }
        // stop attacking
        // move towards the target
    }
    
    private void SetTarget(GameObject newTarget)
    {
        _target = newTarget;
    }
}
