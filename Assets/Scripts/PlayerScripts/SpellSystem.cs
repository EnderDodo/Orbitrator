using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSystem : MonoBehaviour
{
    private InputActions _inputActions;
    private MousePosGetter _mousePosGetter;
    private OrbHolder[] _orbHolders;

    [SerializeField] private int maxSpellLength;
    [SerializeField] private float spellSpawnPointDistance;

    private List<Orb> _orbsToCast; //should be transferred to UI manager

    private Spell _currSpell;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.PlayerDefault.Enable();

        _mousePosGetter = GetComponent<MousePosGetter>();

        _orbHolders = GetComponents<OrbHolder>();
        _orbsToCast = new List<Orb>();

        foreach (var holder in _orbHolders)
        {
            holder.orbInputAction.action.Enable();
            holder.orbInputAction.action.performed += holder.TryAddToSpell;
        }

        _currSpell = new NullSpell();
        Spell.SpellSystem = this;
        _inputActions.PlayerDefault.CastSpell.performed += StartCurrentSpell;
        _inputActions.PlayerDefault.CastSpell.canceled += StopCurrentSpell;
        _currSpell.WasCasted += ClearSpell;
    }

    private void ClearSpell()
    {
        _inputActions.PlayerDefault.CastSpell.performed -= StartCurrentSpell;
        _inputActions.PlayerDefault.CastSpell.canceled -= StopCurrentSpell;
        _currSpell.WasCasted -= ClearSpell;
        _currSpell = new NullSpell();
        _orbsToCast.Clear();
        _inputActions.PlayerDefault.CastSpell.performed += StartCurrentSpell;
        _inputActions.PlayerDefault.CastSpell.canceled += StopCurrentSpell;
        _currSpell.WasCasted += ClearSpell;
    }

    private void StartCurrentSpell(InputAction.CallbackContext context)
    {
        _currSpell.StartCast();
    }

    private void StopCurrentSpell(InputAction.CallbackContext context)
    {
        _currSpell.StopCast();
    }

    public void TryAddToSpell(OrbHolder holder) //contradicting or mixable orbs are expected
    {
        if (holder.orb is not null)
            if (_orbsToCast.Count < maxSpellLength)
            {
                _orbsToCast.Add(holder.orb);
                holder.orb.amountInCurrentSpell++;
                _inputActions.PlayerDefault.CastSpell.performed -= StartCurrentSpell;
                _inputActions.PlayerDefault.CastSpell.canceled -= StopCurrentSpell;
                _currSpell.WasCasted -= ClearSpell;
                _currSpell = _currSpell.AddOrb(holder.orb);
                _inputActions.PlayerDefault.CastSpell.performed += StartCurrentSpell;
                _inputActions.PlayerDefault.CastSpell.canceled += StopCurrentSpell;
                _currSpell.WasCasted += ClearSpell;
                Debug.Log("Tried to add orb to spell!");
            }
    }

    public Vector3 GetPointSpellSpawnPoint()
    {
        return _mousePosGetter.GetMousePosition();
    }

    public Vector3 GetDirectedSpellDirection(out Vector3 playerPosition)
    {
        playerPosition = transform.position;
        playerPosition.z = 0f;
        var mouseWorldPosition = _mousePosGetter.GetMousePosition();
        mouseWorldPosition.z = 0f;
        var direction = (mouseWorldPosition - playerPosition).normalized;
        //Debug.Log($"currSpell direction: {direction}");
        return direction;
    }

    public Vector3 GetDirectedSpellSpawnPoint()
    {
        var direction = GetDirectedSpellDirection(out var playerPos);
        return playerPos + direction * spellSpawnPointDistance;
    }
}