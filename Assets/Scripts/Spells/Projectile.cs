using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public int projectileDamage;
    public int explosionDamage;
    public float explosionRadius;

    //public GameObject Explosion;

    private void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.ApplyDamage(projectileDamage);
            Debug.Log($"Applied {projectileDamage} damage");
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // var explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        // explosion.Damage = ExplosionDamage;
    
        foreach (var item in Physics.OverlapSphere(transform.position, explosionRadius))
        {
            if (item.gameObject.TryGetComponent<Health>(out var health))
            {
                health.ApplyDamage(explosionDamage);
            }
        }
    }
}