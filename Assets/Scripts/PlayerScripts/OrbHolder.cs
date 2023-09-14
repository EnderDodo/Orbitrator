using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class OrbHolder : MonoBehaviour
{
    [SerializeField] [CanBeNull] public Orb orb;
    [SerializeField] public InputActionReference orbInputAction;
    private SpellSystem _spellSystem;

    private void Awake()
    {
        _spellSystem = GetComponent<SpellSystem>();
    }

    public void TryAddToSpell(InputAction.CallbackContext context)
    {
        _spellSystem.TryAddToSpell(this);
    }
    
}
