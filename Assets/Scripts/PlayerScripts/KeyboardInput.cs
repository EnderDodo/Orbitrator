using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    private InputActions _inputActions;
    private PhysicsMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PhysicsMovement>();
        
        _inputActions = new InputActions();
        _inputActions.PlayerDefault.Enable();
    }

    private void FixedUpdate()
    {
        var inputVector = _inputActions.PlayerDefault.Movement.ReadValue<Vector2>();
        _movement.Move(new Vector3(inputVector.x, inputVector.y));
    }

}