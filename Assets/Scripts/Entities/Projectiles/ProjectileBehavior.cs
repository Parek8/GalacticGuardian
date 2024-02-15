using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileBehavior : MonoBehaviour
{
    [field: SerializeField] internal float ShootSpeed { get; private set;} = 4f;
    [SerializeField] private float DMG = 1f;
    public void SetDMG(float dmg)
    {
       DMG = dmg;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        EntityStats _stats;
        if (other.gameObject.TryGetComponent<EntityStats>(out _stats))
        {
            _stats.TakeDamage(DMG);
            Destroy(gameObject);
        }
    }
}