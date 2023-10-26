using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected float rechargeTime;
    protected GameObject Target;
    protected EnemyMovement _enemyMovement;
    protected Animator _animator;

    private PlayerDetection _playerDetection;
    private TargetInPerfectAttackRangeHandler _targetInPerfectAttackRange;
    private TargetTooFarHandler _targetTooFar;
    private TargetTooCloseHandler _targetTooClose;

    private Coroutine _attackCoroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _playerDetection = GetComponentInChildren<PlayerDetection>();
        _targetInPerfectAttackRange = GetComponentInChildren<TargetInPerfectAttackRangeHandler>();
        _targetTooFar = GetComponentInChildren<TargetTooFarHandler>();
        _targetTooClose = GetComponentInChildren<TargetTooCloseHandler>();

        _playerDetection.TargetDetected += SetTarget;
        _targetInPerfectAttackRange.TargetInPerfectRange += StartAttacking;
        _targetTooFar.TargetTooFar += _enemyMovement.StartPursuit;
        _targetTooFar.TargetTooFar += StopAttacking;
        _targetTooClose.TargetTooClose += _enemyMovement.StartRetreat;
        _targetTooClose.TargetTooClose += StopAttacking;
    }

    private void SetTarget(GameObject newTarget)
    {
        Target = newTarget;
        _enemyMovement.SetTarget(newTarget);
        _enemyMovement.StartPursuit();
    }

    protected virtual void StartAttacking()
    {
        if (_attackCoroutine is not null) return;
        _attackCoroutine = StartCoroutine(AttackAndWaitForRecharge());
    }

    protected abstract void PlayAttackAnimation();

    protected abstract void CommitAttack();

    protected virtual void StopAttacking()
    {
        StopCoroutine(_attackCoroutine);
    }

    protected IEnumerator AttackAndWaitForRecharge()
    {
        while (true)
        {
            PlayAttackAnimation();
            yield return new WaitForSeconds(rechargeTime);
        }
    }

    protected Vector3 GetTargetDirection()
    {
        return Target is null
            ? Vector3.zero
            : (Target.transform.position - transform.position).normalized;
    }
}