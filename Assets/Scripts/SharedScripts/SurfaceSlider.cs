using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;
    private Vector3 _direction;
    private Rigidbody _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Vector3 Project(Vector3 direction)
    {
        _direction = direction;
        if (Vector3.Dot(direction, _normal) <= 0)
            return direction - Vector3.Dot(direction, _normal) * _normal;
        return direction;
    }

    
    private void OnCollisionStay(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }

    private void OnCollisionExit(Collision collision)
    {
        _normal = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
    }


    private void OnDrawGizmos()
    {
        var pos = transform.position;
        Gizmos.color = Color.white;
        Gizmos.DrawLine(pos, pos + _normal * 10);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + _direction * 10);
    }
}