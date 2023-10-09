using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int _currHealth;

    public Action<int> HealthChanged;
    
    private void Awake()
    {
        _currHealth = maxHealth;
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
            
        HealthChanged?.Invoke(_currHealth);
    }
}
