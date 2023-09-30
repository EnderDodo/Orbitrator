using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private MousePosGetter _mousePosGetter;
    private Animator _animator;
    private Transform _handsTransform;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    private void Awake()
    {
        _mousePosGetter = GetComponent<MousePosGetter>();
        _animator = GetComponent<Animator>();
        _handsTransform = transform.GetChild(0);
    }

    private void RotateToPointer()
    {
        var mouseWorldPos = _mousePosGetter.GetMousePosition();
        var playerWorldPos = transform.position;
        playerWorldPos.z = 0f;
        var direction = (mouseWorldPos - playerWorldPos).normalized;
        
        _animator.SetFloat(Horizontal, direction.x);
        _animator.SetFloat(Vertical, direction.y);

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _handsTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Update()
    {
        RotateToPointer();
    }
}
