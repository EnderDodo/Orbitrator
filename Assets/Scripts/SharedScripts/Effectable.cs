using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effectable : MonoBehaviour
{
    private List<Effect> _currentEffects = new();

    public void TryAddEffects(List<Effect> newEffects) // contradicting or mixable effects are expected
    {
        if (newEffects is null) return;
        if (newEffects.Count == 0) return;
        var oldEffectsList = CopyEffectsFrom(_currentEffects);
        var newEffectsList = CopyEffectsFrom(newEffects);

        foreach (var newEffect in newEffectsList)
        {
            var wasInCurrentEffects = false;
            var newEffectCopy = CopyEffect(newEffect);
            foreach (var effect in oldEffectsList)
            {
                if (newEffect.name == effect.name)
                {
                    foreach (var currEffect in
                             _currentEffects) //find and refresh respectable currEffect from _currentEffects
                    {
                        if (currEffect.name == effect.name)
                        {
                            currEffect.RefreshEffect();
                            wasInCurrentEffects = true;
                            break;
                        }
                    }

                    break;
                }
            }

            if (wasInCurrentEffects) continue;
            _currentEffects.Add(newEffectCopy);
            newEffectCopy.effectable = this;
            newEffectCopy.StartEffect();
        }

        Debug.Log($"Current Effects Amount:{_currentEffects.Count}");
    }

    public void RemoveEffect(Effect effect)
    {
        _currentEffects.Remove(effect);
    }

    public List<Effect> CopyEffectsFrom(List<Effect> oldEffects)
    {
        List<Effect> newEffects = new();
        foreach (var oldEffect in oldEffects)
        {
            var effect = CopyEffect(oldEffect);
            newEffects.Add(effect);
        }

        return newEffects;
    }

    public Effect CopyEffect(Effect oldEffect)
    {
        Effect effect;
        switch (oldEffect)
        {
            case HealthOTEffect:
                effect = ScriptableObject.CreateInstance<HealthOTEffect>();
                effect.CopyDataFrom(oldEffect);
                break;
            case SpeedEffect:
                effect = ScriptableObject.CreateInstance<SpeedEffect>();
                effect.CopyDataFrom(oldEffect);
                break;
            default:
                effect = ScriptableObject.CreateInstance<HealthOTEffect>();
                break;
        }

        return effect;
    }

    // private void OnDestroy()
    // {
    //     StopAllCoroutines();
    // }
}