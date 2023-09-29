using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private SurfaceSlider _slider;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _slider = GetComponent<SurfaceSlider>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 offset = _slider.Project(direction) * (speed * Time.deltaTime);

        _rigidBody.MovePosition(_rigidBody.position + offset);

        // if (CompareTag("Player"))
        // Debug.Log("teehee");

        //_rigidBody.velocity = offset;
        //transform.position += offset;
        //_rigidBody.AddForce(offset);
        //transform.Translate(offset);
    }

    public void OnDrawGizmos()
    {
        var pos = transform.position;
        var vel = _rigidBody.velocity;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(pos, pos + vel * 10);
    }
}