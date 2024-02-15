using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
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
