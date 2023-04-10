using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private PhysicsMovement _movement;

    private OrbHolder[] _orbHolders;
    private SpellSystem _spellSystem;

    public event Action<OrbHolder> OrbKeyDown;
    public event Action CastKeyDown;

    private void Awake()
    {
        _movement = GetComponent<PhysicsMovement>();
        _orbHolders = GetComponents<OrbHolder>();
        _spellSystem = GetComponent<SpellSystem>();
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal"); //"horizontal" may have problems with Unity?
        var vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
            _movement.Move(Vector3.ClampMagnitude(new Vector3(horizontal, vertical), 1));
    }

    private void Update()
    {
        foreach (var holder in _orbHolders) //should be remade using new input system 
        {
            if (Input.GetKeyDown(holder.orbKey))
            {
                OrbKeyDown?.Invoke(holder);
                //Debug.Log("Orb Key pressed!");
            }
        }

        if (Input.GetKeyDown(_spellSystem.CastKey))
        {
            CastKeyDown?.Invoke();
            Debug.Log("Cast Key pressed!");
        }
    }
}