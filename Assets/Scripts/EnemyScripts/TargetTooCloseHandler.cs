using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TargetTooCloseHandler : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private PlayerDetection playerDetection;
    
    public Action TargetTooClose;

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
            TargetTooClose?.Invoke();
        }
        // stop attacking
        // move away from target
    }

    private void SetTarget(GameObject newTarget)
    {
        _target = newTarget;
    }
}
