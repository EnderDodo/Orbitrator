using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySlamAttack : EnemyAttack
{
    [SerializeField] private int damage;
    [SerializeField] private float jumpForwardSpeed;
    [SerializeField] private float jumpBackwardSpeed;
    protected override void StartAttacking()
    {
        
    }

    protected override void PlayAttackAnimation()
    {
        throw new System.NotImplementedException();
    }

    protected override void CommitAttack()
    {
        throw new System.NotImplementedException();
    }

    protected override void StopAttacking()
    {
        throw new System.NotImplementedException();
    }
}
