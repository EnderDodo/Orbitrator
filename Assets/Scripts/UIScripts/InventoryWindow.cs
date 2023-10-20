using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryWindow : MonoBehaviour
{
    private InputActions _inputActions;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Inventory.CloseInventory.performed += CloseInventory;
        _inputActions.PlayerDefault.OpenInventory.performed += OpenInventory;
        gameObject.SetActive(false);
    }

    private void OpenInventory(InputAction.CallbackContext obj)
    {
        gameObject.SetActive(true);
        _inputActions.PlayerDefault.Disable();
        _inputActions.Inventory.Enable();
    }
    
    private void CloseInventory(InputAction.CallbackContext obj)
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _inputActions.Inventory.Disable();
        _inputActions.PlayerDefault.Enable();
    }
}
