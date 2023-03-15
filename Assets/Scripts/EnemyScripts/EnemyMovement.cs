using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PhysicsMovement movement;
    private GameObject _target;

    void Awake()
    {
        _target = FindObjectOfType(typeof(KeyboardInput)).GameObject();
    }

    void Update()
    {
        movement.Move(Vector3.ClampMagnitude(_target.transform.position - transform.position, 1));
    }
}
