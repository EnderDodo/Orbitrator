using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : MonoBehaviour
{
    private KeyboardInput _input;
    [SerializeField] public KeyCode CastKey;
    
    [SerializeField] private int maxSpellLength;

    private List<Orb> _orbsToCast; //should be transferred to UI manager

    public Spell CurrSpell;

    private void Awake()
    {
        _orbsToCast = new List<Orb>();
        _input = GetComponent<KeyboardInput>();
        _input.OrbKeyDown += TryAddToSpell;
        CurrSpell = new NullSpell();
        Spell.SpellSystem = this;
        _input.CastKeyDown += CurrSpell.Cast;
        CurrSpell.WasCasted += ClearSpell;
    }

    private void ClearSpell()
    {
        _input.CastKeyDown -= CurrSpell.Cast;
        CurrSpell.WasCasted -= ClearSpell;
        CurrSpell = new NullSpell();
        _orbsToCast.Clear();
        _input.CastKeyDown += CurrSpell.Cast;
        CurrSpell.WasCasted += ClearSpell;
    }

    private void TryAddToSpell(OrbHolder holder) //contradicting or mixable orbs are expected
    {
        if (holder.orb is not null)
            if (_orbsToCast.Count < maxSpellLength)
            {
                _orbsToCast.Add(holder.orb);
                holder.orb.amountInCurrentSpell++;
                _input.CastKeyDown -= CurrSpell.Cast;
                CurrSpell.WasCasted -= ClearSpell;
                CurrSpell = CurrSpell.AddOrb(holder.orb);
                _input.CastKeyDown += CurrSpell.Cast;
                CurrSpell.WasCasted += ClearSpell;
                Debug.Log("Tried to add orb to spell!");
            }
    }
}