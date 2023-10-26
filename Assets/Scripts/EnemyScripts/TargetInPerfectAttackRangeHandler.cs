using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInPerfectAttackRangeHandler : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private PlayerDetection playerDetection;
    
    public Action TargetInPerfectRange;

    private void Awake()
    {
        //playerDetection = transform.parent.GetComponentInChildren<PlayerDetection>();
        playerDetection.TargetDetected += SetTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_target is null) return;
        if (other.gameObject == _target)
        {
            TargetInPerfectRange?.Invoke();
        }
        // start attacking
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (_target is null) return;
        if (other.gameObject == _target)
        {
            TargetInPerfectRange?.Invoke();
        }
        // start attacking
    }

    private void SetTarget(GameObject newTarget)
    {
        _target = newTarget;
    }
}
