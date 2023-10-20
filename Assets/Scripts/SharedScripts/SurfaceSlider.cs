using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private List<Rigidbody> _collidedRigidbodies;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collidedRigidbodies = new List<Rigidbody>();
    }

    public Vector3 Project(Vector3 direction)
    {
        _direction = direction;
        if (Vector3.Dot(direction, _normal) <= 0)
            return direction - Vector3.Dot(direction, _normal) * _normal;
        return direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody is not null)
        {
            _collidedRigidbodies.Add(collision.rigidbody);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        _normal = collision.GetContact(0).normal;
    }

    private void OnCollisionExit(Collision collision)
    {
        _normal = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        if (collision.rigidbody is not null)
        {
            _collidedRigidbodies.Remove(collision.rigidbody);
        }
    }

    // private void OnDisable() //after destroying/disabling game object set velocities of all collision to 0
    // {
    //     foreach (var otherRigidbody in _collidedRigidbodies)
    //     {
    //         otherRigidbody.velocity = Vector3.zero;
    //     }
    // }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        // Gizmos.color = Color.white;
        // Gizmos.DrawLine(pos, pos + _normal * 10);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + _direction * 10);
        // Gizmos.color = Color.blue;
        // Gizmos.DrawLine(pos, pos + _rigidbody.velocity * 10);
    }
}