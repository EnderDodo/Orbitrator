using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement movement;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //"horizontal" may have problems with Unity?
        float vertical = Input.GetAxis("Vertical");

        movement.Move(Vector3.ClampMagnitude(new Vector3(horizontal, vertical), 1));
    }
}
