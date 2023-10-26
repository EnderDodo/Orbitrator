using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PhysicsMovement _movement;
    private Vector3 _targetDirection;
    private GameObject _target;
    private int _directionMultiplier;

    private Animator _animator;
    private static readonly int MoveHorizontal = Animator.StringToHash("MoveHorizontal");
    private static readonly int MoveVertical = Animator.StringToHash("MoveVertical");

    private void Awake()
    {
        _movement = GetComponent<PhysicsMovement>();
        _targetDirection = new Vector3(0, 0, 0);
        TryGetComponent(out _animator);
    }

    private void FixedUpdate()
    {
        if (_target is not null)
        {
            _targetDirection =
                ((_target.transform.position - transform.position) * _directionMultiplier).normalized;
        }

        _movement.Move(_targetDirection);
        if (_animator is not null)
        {
            _animator.SetFloat(MoveHorizontal, _targetDirection.x);
            _animator.SetFloat(MoveVertical, _targetDirection.y);
        }
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public void StartPursuit()
    {
        _directionMultiplier = 1;
    }

    public void StartRetreat()
    {
        _directionMultiplier = -1;
    }

    public void StopMoving()
    {
        _directionMultiplier = 0;
    }
}