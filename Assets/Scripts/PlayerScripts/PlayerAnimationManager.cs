using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private MousePosGetter _mousePosGetter;
    private Animator _animator;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    private void Awake()
    {
        _mousePosGetter = GetComponent<MousePosGetter>();
        _animator = GetComponent<Animator>();
    }

    private void RotateToPointer()
    {
        var mouseWorldPos = _mousePosGetter.GetMousePosition();
        var playerWorldPos = transform.position;
        playerWorldPos.z = 0f;
        var direction = (mouseWorldPos - playerWorldPos).normalized;
        
        _animator.SetFloat(Horizontal, direction.x);
        _animator.SetFloat(Vertical, direction.y);
    }

    private void Update()
    {
        RotateToPointer();
    }
}
