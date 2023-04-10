using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PhysicsMovement movement;
    private GameObject _target;

    private void Awake()
    {
        _target = FindObjectOfType(typeof(KeyboardInput)).GameObject();
    }

    private void FixedUpdate()
    {
        movement.Move(Vector3.ClampMagnitude(_target.transform.position - transform.position, 1));
    }
}
