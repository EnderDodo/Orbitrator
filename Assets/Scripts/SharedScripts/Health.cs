using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int _currHealth;
    // [SerializeField] private float invincibilityTime; - move to InvincibilityHandler.cs in future
    // private Coroutine _invincibilityCoroutine;
    // private WaitForSeconds _invincibilityWait;

    public Action<int> HealthChanged;

    private void Awake()
    {
        _currHealth = maxHealth;
        // _invincibilityWait = new WaitForSeconds(invincibilityTime);
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currHealth -= damage;
        if (_currHealth <= 0)
        {
            _currHealth = 0;
            Destroy(gameObject);
        }

        if (_currHealth > maxHealth) //what if someone will inflict negative damage???
            _currHealth = maxHealth;
        // _invincibilityCoroutine ??= StartCoroutine(TakeDamageWaitForInvincibilityTime(damage));
        // ??= - assign new coroutine only if _invincibilityCoroutine is null
        HealthChanged?.Invoke(_currHealth);
    }

    // private IEnumerator TakeDamageWaitForInvincibilityTime(int damage)
    // {
    //     yield return _invincibilityWait;
    //     StopCoroutine(_invincibilityCoroutine);
    // }
}