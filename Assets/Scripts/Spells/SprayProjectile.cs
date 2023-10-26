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
    public List<Effect> projectileEffects;
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
        if (other.gameObject.TryGetComponent<TargetTooCloseHandler>(out var a)) return;
        if (other.gameObject.TryGetComponent<TargetTooFarHandler>(out var s)) return;
        if (other.gameObject.TryGetComponent<PlayerDetection>(out var d)) return;
        if (other.gameObject.TryGetComponent<TargetInPerfectAttackRangeHandler>(out var f)) return;
        if (other.gameObject.TryGetComponent<Health>(out var health))
        {
            health.ApplyDamage(damage);
        }
        if (other.gameObject.TryGetComponent<Effectable>(out var effectable))
        {
            effectable.TryAddEffects(projectileEffects);
        }

        Destroy(gameObject);
    }
}