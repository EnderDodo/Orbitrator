using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;
    private Vector3 _direction;
    
    public Vector3 Project(Vector3 direction)
    {
        _direction = direction;
        if (Vector3.Dot(direction, _normal) <= 0)
            return direction - Vector3.Dot(direction, _normal) * _normal;
        return direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }

    private void OnCollisionExit(Collision collision)
    {
        _normal = new Vector3(0, 0, 0);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 10);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _direction * 10);
    }
}