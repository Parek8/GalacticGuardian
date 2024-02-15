using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileBehavior : MonoBehaviour
{
    [field: SerializeField] internal float ShootSpeed { get; private set;} = 4f;
    [SerializeField] private float DMG = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetDMG(float dmg)
    {
       DMG = dmg;
    }
}
