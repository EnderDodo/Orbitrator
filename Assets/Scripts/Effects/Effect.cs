using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;


public abstract class Effect : ScriptableObject
{
    [HideInInspector] public Effectable effectable;
    [SerializeField] protected GameObject particles;
    protected GameObject CurrParticles;
    public float timeSpan;
    protected Coroutine EffectCoroutine;
    protected float CurrTime = 0f;

    public virtual void CopyDataFrom(Effect effect)
    {
        particles = effect.particles;
        effectable = effect.effectable;
        timeSpan = effect.timeSpan;
        EffectCoroutine = effect.EffectCoroutine;
    }

    public virtual void StartEffect()
    {
        if (particles is not null)
        {
            CurrParticles = Instantiate(particles, effectable.transform);
        }
    }

    public virtual void EndEffect() 
    {
        if (CurrParticles is not null)
        {
            Destroy(CurrParticles);
        }
        if (EffectCoroutine is not null && effectable is not null)
        {
            effectable.RemoveEffect(this);
            effectable.StopCoroutine(EffectCoroutine);
        }
    }

    public void RefreshEffect()
    {
        CurrTime = 0f;
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