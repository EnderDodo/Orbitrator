using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private SurfaceSlider slider;
    [SerializeField] private float speed;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 offset = slider.Project(direction) * (speed * Time.deltaTime);

        _rigidBody.MovePosition(_rigidBody.position + offset);
        
        // if (CompareTag("Player"))
        // Debug.Log("teehee");
        
        //transform.position += offset;
        //_rigidBody.AddForce(offset);
        //transform.Translate(offset);
    }
}
