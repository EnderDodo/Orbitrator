using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayProjectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public int damage;
    public float maxDistance;
    private float _currDistance = 0f;

    private void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
        while (_currDistance < maxDistance)
        {
            _currDistance += speed * Time.deltaTime;
            return;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<SprayProjectile>(out var sprayProjectile)) return;
        if (other.gameObject.TryGetComponent<Health>(out var health))
        {
            health.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }
}