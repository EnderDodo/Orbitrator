using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speed Effect", menuName = "Effect/Speed Effect")]
public class SpeedEffect : Effect
{
    public float speedChangeFraction = 1f;
    private PhysicsMovement _physicsMovement;

    public override void CopyDataFrom(Effect effect)
    {
        base.CopyDataFrom(effect);
        speedChangeFraction = ((SpeedEffect)effect).speedChangeFraction;
    }

    public override void StartEffect()
    {
        base.StartEffect();
        EffectCoroutine = effectable.StartCoroutine(ChangeSpeedByFraction());
    }

    public override void EndEffect()
    {
        if (_physicsMovement is not null)
            _physicsMovement.SetSpeed(_physicsMovement.GetBaseSpeed());
        base.EndEffect();
    }

    private IEnumerator ChangeSpeedByFraction()
    {
        if (effectable.TryGetComponent(out _physicsMovement))
            _physicsMovement.SetSpeed(_physicsMovement.GetSpeed() * speedChangeFraction);
        while (CurrTime < timeSpan)
        {
            CurrTime += Time.deltaTime;
            yield return null;
        }
        EndEffect();
    }
}