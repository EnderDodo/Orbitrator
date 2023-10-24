using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Over Time Effect", menuName = "Effect/HealthOT Effect")]
public class HealthOTEffect : Effect
{
    public int healthChange;
    public float timeBetweenChanges = 1f;

    public override void CopyDataFrom(Effect effect)
    {
        base.CopyDataFrom(effect);
        healthChange = ((HealthOTEffect)effect).healthChange;
        timeBetweenChanges = ((HealthOTEffect)effect).timeBetweenChanges;
    }

    public override void StartEffect()
    {
        base.StartEffect();
        EffectCoroutine = effectable.StartCoroutine(ChangeHealthOverTime());
    }

    public override void EndEffect()
    {
        base.EndEffect();
    }

    private IEnumerator ChangeHealthOverTime()
    {
        if (effectable.TryGetComponent<Health>(out var effectedHealth))
        {
            while (CurrTime < timeSpan)
            {
                effectedHealth.ApplyDamage(-healthChange);

                CurrTime += timeBetweenChanges;
                yield return new WaitForSeconds(timeBetweenChanges);
            }
        }

        else
        {
            while (CurrTime < timeSpan)
            {
                CurrTime += timeBetweenChanges;
                yield return new WaitForSeconds(timeBetweenChanges);
            }
        }
        EndEffect();
    }
}