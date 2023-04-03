using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spellmaking : MonoBehaviour
{
    private KeyboardInput _input;
    [SerializeField] private int maxSpellLength;

    private List<Orb> _orbsToCast; //should be transferred to UI manager

    private Spell _currSpell;

    private void Awake()
    {
        _orbsToCast = new List<Orb>();
        _input = GetComponent<KeyboardInput>();
        _input.OrbButtonDown += TryAddToSpell;
        _currSpell = new NullSpell();
    }

    private void TryAddToSpell(OrbHolder holder) //contradicting or mixable orbs are expected
    {
        if (holder.orb is not null)
            if (_orbsToCast.Count < maxSpellLength)
            {
                _orbsToCast.Add(holder.orb);
                holder.orb.amountInCurrentSpell++;
                _currSpell.AddOrb(holder.orb);
            }
    }
}