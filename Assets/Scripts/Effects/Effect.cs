using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public abstract class Effect : ScriptableObject
{
    [HideInInspector] public Effectable effectable;
    public float timeSpan;
    public Coroutine EffectCoroutine;
    protected float currTime = 0f;

    public virtual void CopyDataFrom(Effect effect)
    {
        effectable = effect.effectable;
        timeSpan = effect.timeSpan;
        EffectCoroutine = effect.EffectCoroutine;
    }
    public abstract void StartEffect();

    public virtual void EndEffect()
    {
        if (EffectCoroutine is not null && effectable is not null)
        {
            effectable.RemoveEffect(this);
            effectable.StopCoroutine(EffectCoroutine);
        }
    }

    public void RefreshEffect()
    {
        currTime = 0f;
    }

    public List<Effect> AddToList(List<Effect> list)
    {
        if (list is null)
        {
            var newList = new List<Effect> { this };
            return newList;
        }

        foreach (var effect in list)
            if (effect.name == name)
                return list;
        list.Add(this);
        return list;
    }
    
}