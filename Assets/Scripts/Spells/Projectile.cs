using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public int projectileDamage;
    public int explosionDamage;
    public float explosionRadius;
    public List<Effect> projectileEffects;
    public List<Effect> explosionEffects;
    [SerializeField] private GameObject explosionParticleSystem;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.Translate(direction * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.ApplyDamage(projectileDamage);
            Debug.Log($"Applied {projectileDamage} damage");
        }

        if (collision.gameObject.TryGetComponent<Effectable>(out var effectable))
        {
            effectable.TryAddEffects(projectileEffects);
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (explosionRadius > 0 && explosionParticleSystem is not null)
        {
            var explosion = Instantiate(explosionParticleSystem, _transform.position, Quaternion.identity);
            var particleSys = explosion.GetComponent<ParticleSystem>();
            var mainModule = particleSys.main;
            mainModule.startLifetime = explosionRadius / 10;
        }

        foreach (var item in Physics.OverlapSphere(transform.position, explosionRadius))
        {
            if (item.gameObject.TryGetComponent<Health>(out var health))
            {
                health.ApplyDamage(explosionDamage);
            }

            if (item.gameObject.TryGetComponent<Effectable>(out var effectable))
            {
                effectable.TryAddEffects(explosionEffects);
            }
        }
    }
}