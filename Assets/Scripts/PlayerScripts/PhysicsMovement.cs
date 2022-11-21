using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private SurfaceSlider surfaceSlider;
    [SerializeField] private float speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 offset = surfaceSlider.Project(direction) * speed * Time.deltaTime;

        rb.MovePosition(rb.position + offset);
        //transform.position += offset;
    }
}
