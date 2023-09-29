using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowing : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraOffset;

    private void Update()
    {
        transform.position = playerTransform.position + cameraOffset;
    }
}
