using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSystem : MonoBehaviour
{
    private InputActions _inputActions;
    private OrbHolder[] _orbHolders;

    [SerializeField] private int maxSpellLength;

    private List<Orb> _orbsToCast; //should be transferred to UI manager

    private Spell _currSpell;

    private void Awake()
    {
        _orbHolders = GetComponents<OrbHolder>();

        _orbsToCast = new List<Orb>();
        _inputActions = new InputActions();
        _inputActions.PlayerDefault.Enable();
        
        foreach (var holder in _orbHolders)
        {
            holder.orbInputAction.action.Enable();
            holder.orbInputAction.action.performed += holder.TryAddToSpell;
        }

        _currSpell = new NullSpell();
        Spell.SpellSystem = this;
        _inputActions.PlayerDefault.CastSpell.performed += CastCurrentSpell;
        _currSpell.WasCasted += ClearSpell;
    }

    private void ClearSpell()
    {
        _inputActions.PlayerDefault.CastSpell.performed -= CastCurrentSpell;
        _currSpell.WasCasted -= ClearSpell;
        _currSpell = new NullSpell();
        _orbsToCast.Clear();
        _inputActions.PlayerDefault.CastSpell.performed += CastCurrentSpell;
        _currSpell.WasCasted += ClearSpell;
    }

    private void CastCurrentSpell(InputAction.CallbackContext context)
    {
        _currSpell.Cast();
    }

    public void TryAddToSpell(OrbHolder holder) //contradicting or mixable orbs are expected
    {
        if (holder.orb is not null)
            if (_orbsToCast.Count < maxSpellLength)
            {
                _orbsToCast.Add(holder.orb);
                holder.orb.amountInCurrentSpell++;
                _inputActions.PlayerDefault.CastSpell.performed -= CastCurrentSpell;
                _currSpell.WasCasted -= ClearSpell;
                _currSpell = _currSpell.AddOrb(holder.orb);
                _inputActions.PlayerDefault.CastSpell.performed += CastCurrentSpell;
                _currSpell.WasCasted += ClearSpell;
                Debug.Log("Tried to add orb to spell!");
            }
    }

}