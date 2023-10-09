using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class SprayProjectile : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    public Vector3 direction;
    public float speed;
    public int damage;
    public float maxDistance;
    public float growthPerSecond;
    private float _currDistance;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = gradient.Evaluate(0f);
    }

    private void Update()
    {
        _transform.Translate(direction * (speed * Time.deltaTime));
        _transform.localScale += new Vector3(growthPerSecond * Time.deltaTime, growthPerSecond * Time.deltaTime, 0);
        while (_currDistance < maxDistance)
        {
            _spriteRenderer.color = gradient.Evaluate(_currDistance / maxDistance); 
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