using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float velocity;
    private Vector3 direction;
    
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        direction = Vector3.ClampMagnitude(direction, 1);

        transform.position += direction * velocity * Time.deltaTime;
    }

    void FixedUpdate()
    {
            
    }
}
