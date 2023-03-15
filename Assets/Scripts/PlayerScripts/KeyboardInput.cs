using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement movement;
    [SerializeField] private KeyCode orb1 = KeyCode.Alpha1; //reimplement with array?
    [SerializeField] private KeyCode orb2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode orb3 = KeyCode.Alpha3;
    [SerializeField] private KeyCode orb4 = KeyCode.Alpha4;
    [SerializeField] private KeyCode orb5 = KeyCode.Alpha5;
    [SerializeField] private KeyCode orb6 = KeyCode.Alpha6;

        //public KeyCode[] orbButton = new KeyCode[/**/]; 
    public event Action<KeyCode> OrbButtonDown;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //"horizontal" may have problems with Unity?
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(orb1))
        {
            OrbButtonDown?.Invoke(orb1);
        }

        movement.Move(Vector3.ClampMagnitude(new Vector3(horizontal, vertical), 1));
    }
}
