using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosGetter : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public Vector3 GetMousePosition()
    {
        var mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        //Debug.Log($"mouse pos: {mouseWorldPosition}");
        return mouseWorldPosition;
    }
}