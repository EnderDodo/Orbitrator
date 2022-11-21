using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 normal;

    public Vector3 Project(Vector3 direction)
    {
        if (Vector3.Dot(direction, normal) <= 0)
            return direction - Vector3.Dot(direction, normal) * normal;
        else
            return direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        normal = collision.contacts[0].normal;
    }

    private void OnCollisionExit(Collision collision)
    {
        normal = new Vector3(0, 0, 0);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + normal * 10);
    }
}
