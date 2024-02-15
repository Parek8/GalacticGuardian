using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    EntityStats playerStats;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPosition;

    void Start()
    {
        playerStats = GetComponent<EntityStats>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            CreateProjectile();
        }
    }
    void CreateProjectile()
    {
        ProjectileBehavior projectileBehavior = projectilePrefab.GetComponent<ProjectileBehavior>();
        projectileBehavior.SetDMG(playerStats.AttackDamage);
        Debug.Log("succ");

    }
}
