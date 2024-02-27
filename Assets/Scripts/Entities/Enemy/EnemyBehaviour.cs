using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EntityStats))]
public class EnemyBehaviour : MonoBehaviour
{
    [field: SerializeField] internal GameObject BulletPrefab { get; private set;}
    [field: SerializeField] internal Transform BulletSpawnPoint { get; private set;}
    EntityStats _enemyStats;
    EnemyMovement _enemyMovement;

    float _currentShootCooldown;
    void Start()
    {
        _enemyStats = GetComponent<EntityStats>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _currentShootCooldown = _enemyStats.ShootCooldown;
    }

    void Update()
    {
        _currentShootCooldown -= Time.deltaTime;
        if (_enemyMovement.Agro && _currentShootCooldown <= 0)
            Shoot();
    }
    private void Shoot()
    {
        GameObject _bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        _bullet.GetComponent<Rigidbody2D>().AddForce(BulletSpawnPoint.up * _bullet.GetComponent<ProjectileBehavior>().ShootSpeed);

        _currentShootCooldown = _enemyStats.ShootCooldown;
    }
}