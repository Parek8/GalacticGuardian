using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(EntityStats))]
internal class PlayerBehaviour : MonoBehaviour
{
    [field: SerializeField] private GameObject BulletPrefab;
    [field: SerializeField] private Transform BulletSpawnPoint;
    [field: SerializeField] private Image CooldownImage;



    EntityStats _playerStats;
    float _currentShootCooldown;
    float _maxShootCooldown;
    bool _bulletUpgraded = false;

    void Start()
    {
        _playerStats = GetComponent<EntityStats>();
        _maxShootCooldown = _playerStats.ShootCooldown;
        _currentShootCooldown = _maxShootCooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentShootCooldown <= 0)
            Shoot();

        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        _currentShootCooldown -= Time.deltaTime;
        float _filledAmount = _currentShootCooldown / _maxShootCooldown;

        CooldownImage.fillAmount = _filledAmount;
        if (_currentShootCooldown < 1 && !CooldownImage.gameObject.activeInHierarchy)
            CooldownImage.gameObject.SetActive(true);
        else if(_currentShootCooldown >= 1 && CooldownImage.gameObject.activeInHierarchy)
            CooldownImage.gameObject.SetActive(false);

    }
    private void Shoot()
    {
        GameObject _bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
        _bullet.GetComponent<Rigidbody2D>().AddForce(BulletSpawnPoint.up * _bullet.GetComponent<ProjectileBehavior>().ShootSpeed);

        _currentShootCooldown = _maxShootCooldown;
    }
}