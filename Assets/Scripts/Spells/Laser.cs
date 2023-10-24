using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Laser : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    
    public Vector3 startingPoint;
    public Vector3 direction;
    public float maxDistance;
    public int damage;
    public List<Effect> effects;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        var ray = new Ray(startingPoint, direction);
        var cast = Physics.Raycast(ray, out var hit, maxDistance);
        var hitPoint = cast ? hit.point : startingPoint + direction * maxDistance;
        
        _lineRenderer.SetPosition(0, startingPoint);
        _lineRenderer.SetPosition(1, hitPoint);
        
        if (cast && hit.collider.TryGetComponent<Health>(out var health))
        {
            health.ApplyDamage(damage);
        }
        if (cast && hit.collider.TryGetComponent<Effectable>(out var effectable))
        {
            effectable.TryAddEffects(effects);
        }
    }
    
}
