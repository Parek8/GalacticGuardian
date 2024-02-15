using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(EntityStats))]
internal class PlayerBehaviour : MonoBehaviour
{
    [field: SerializeField] private GameObject BulletPrefab;
    [field: SerializeField] private Transform BulletSpawnPoint;
    EntityStats _playerStats;
    float _currentShootCooldown;

    bool _bulletUpgraded = false;


    void Start()
    {
        _playerStats = GetComponent<EntityStats>();
        _currentShootCooldown = _playerStats.ShootCooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentShootCooldown <= 0)
        {
            Shoot();
        }

        _currentShootCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
        _bullet.GetComponent<Rigidbody2D>().AddForce(BulletSpawnPoint.up * _bullet.GetComponent<ProjectileBehavior>().ShootSpeed);

        _currentShootCooldown = _playerStats.ShootCooldown;
    }
}