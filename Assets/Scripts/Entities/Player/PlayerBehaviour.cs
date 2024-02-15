using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(EntityStats))]
internal class PlayerBehaviour : MonoBehaviour
{
    [field: SerializeField] private GameObject BulletPrefab;
    EntityStats _playerStats;
    float _currentShootCooldown;

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
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(BulletPrefab);
        _bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * _bullet.GetComponent<EntityStats>().ShootSpeed);

        _currentShootCooldown = _playerStats.ShootCooldown;
    }
}