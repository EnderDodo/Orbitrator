using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectileAttack : EnemyAttack
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpawnDistance;
    private Vector3 projectileSpawnPosition;
    
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int PlayerPosHorizontal = Animator.StringToHash("PlayerPosHorizontal");

    protected override void PlayAttackAnimation()
    {
        _enemyMovement.StopMoving();
        _animator.SetFloat(PlayerPosHorizontal, GetTargetDirection().x);
        _animator.SetTrigger(Attack);
    }

    protected override void CommitAttack()
    {
        if (projectile is null) return;
        var direction = GetTargetDirection();
        projectileSpawnPosition = transform.position + direction * projectileSpawnDistance;
        var currProj = Instantiate(projectile, projectileSpawnPosition, Quaternion.identity);
        
        //var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //currProj.transform.eulerAngles = new Vector3(0, 0, angle);
        
        var stats = currProj.GetComponent<Projectile>();
        stats.direction = direction;
    }
    
}
