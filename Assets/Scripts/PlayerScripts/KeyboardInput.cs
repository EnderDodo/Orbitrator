using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement movement;

    private OrbHolder[] _orbHolders;

    public event Action<OrbHolder> OrbButtonDown;

    private void Awake()
    {
        _orbHolders = GetComponents<OrbHolder>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal"); //"horizontal" may have problems with Unity?
        var vertical = Input.GetAxis("Vertical");
        movement.Move(Vector3.ClampMagnitude(new Vector3(horizontal, vertical), 1));

        foreach (var holder in _orbHolders) //should be remade using new input system 
        {
            if (Input.GetKeyDown(holder.key))
            {
                OrbButtonDown?.Invoke(holder);
            }
        }
        
        if (Input.GetKeyDown())
        //spellcast button check is needed
    }
    
}