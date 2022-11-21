using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    [SerializeField] private Slider slider;
    [SerializeField] private Image filling;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        filling.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int currHealth)
    {
        slider.value = currHealth;

        filling.color = gradient.Evaluate(slider.normalizedValue);
    }
}
