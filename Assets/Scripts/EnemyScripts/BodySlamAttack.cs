using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BodySlamAttack : EnemyAttack
{
    [SerializeField] private PhysicsMovement movement;
    [SerializeField] private int contactDamage;
    [SerializeField] private float jumpForwardSpeed;
    [SerializeField] private float jumpForwardTime;
    [SerializeField] private float jumpBackwardSpeed;
    [SerializeField] private float jumpBackwardTime;

    private Coroutine _jumpCoroutine;

    protected override void PlayAttackAnimation()
    {
        _enemyMovement.StopMoving();
        CommitAttack(); //CommitAttack should be invoked via animation event
    }

    protected override void CommitAttack()
    {
        var direction = GetTargetDirection();
        DirectionJump(direction, jumpForwardSpeed, jumpForwardTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != Target) return;
        if (other.gameObject.TryGetComponent<Health>(out var health))
            health.ApplyDamage(contactDamage);
        DirectionJump(-GetTargetDirection(), jumpBackwardSpeed, jumpBackwardTime);
    }

    private void DirectionJump(Vector3 direction, float speed, float time)
    {
        _enemyMovement.StopMoving();
        if (_jumpCoroutine is not null)
        {
            movement.SetSpeed(movement.GetBaseSpeed());
            StopCoroutine(_jumpCoroutine);
        }
        _jumpCoroutine = StartCoroutine(Jump(direction, speed, time));
    }

    private IEnumerator Jump(Vector3 direction, float speed, float time)
    {
        var currTime = 0f;
        movement.SetSpeed(speed);
        while (currTime < time)
        {
            movement.Move(direction);
            currTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        movement.SetSpeed(movement.GetBaseSpeed());
    }
}