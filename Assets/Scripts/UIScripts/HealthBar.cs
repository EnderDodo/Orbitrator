using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    [SerializeField] private Slider slider;
    [SerializeField] private Image filling;
    [FormerlySerializedAs("ownerHealthScript")] [SerializeField] private Health ownerHealth;

    private void Awake()
    {
        SetMaxHealth(ownerHealth.maxHealth);
        ownerHealth.HealthChanged += SetHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        filling.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int currHealth)
    {
        slider.value = currHealth;
        Debug.Log(currHealth);
        filling.color = gradient.Evaluate(slider.normalizedValue);
    }
    
    
}
