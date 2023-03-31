using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement movement;

    private OrbHolder[] _orbHolders;

    public event Action<OrbHolder> OrbButtonDown;

    void Awake()
    {
        _orbHolders = GetComponents<OrbHolder>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //"horizontal" may have problems with Unity?
        float vertical = Input.GetAxis("Vertical");
        movement.Move(Vector3.ClampMagnitude(new Vector3(horizontal, vertical), 1));

        foreach (var holder in _orbHolders) //should be remade using new input system 
        {
            if (Input.GetKeyDown(holder.key))
            {
                OrbButtonDown?.Invoke(holder);
            }
        }
        
        //spellcast button check is needed
    }
    
}