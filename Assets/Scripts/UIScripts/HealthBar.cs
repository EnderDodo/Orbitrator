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

    [FormerlySerializedAs("ownerHealthScript")] [SerializeField]
    private Health ownerHealth;

    [SerializeField] private float lerpSpeed = 0.3f;
    [SerializeField] private float timeBetweenLerp = 0.02f;
    private Coroutine settingHealth;
    private WaitForSeconds lerpWait;

    private void Awake()
    {
        SetMaxHealth(ownerHealth.maxHealth);
        ownerHealth.HealthChanged += SetHealth;
        lerpWait = new WaitForSeconds(timeBetweenLerp);
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        filling.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int currHealth)
    {
        if (settingHealth != null)
            StopCoroutine(settingHealth);
        settingHealth = StartCoroutine(LerpHealth(currHealth));
        // slider.value = currHealth;
        Debug.Log(currHealth);
    }

    IEnumerator LerpHealth(int currHealth)
    {
        while (slider.value - currHealth > 1f)
        {
            slider.value = Mathf.Lerp(slider.value, currHealth, lerpSpeed);
            filling.color = gradient.Evaluate(slider.normalizedValue);
            yield return lerpWait;
        }

        slider.value = currHealth;
    }
}