﻿using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerStats))]
internal class PlayerBehaviour : MonoBehaviour
{
    [field: SerializeField] private GameObject BulletPrefab;
    [field: SerializeField] private Transform BulletSpawnPoint;
    [field: SerializeField] private Image CooldownImage;
    [field: SerializeField] private Image GreenHPImage;
    [field: SerializeField] private Image RedHPImage;
    [field: SerializeField] private TMP_Text CopperText;
    [field: SerializeField] TMP_Text ScoreText;
    [field: SerializeField] private Transform MinimapCamera;

    PlayerStats _playerStats;
    float _currentShootCooldown;
    float _maxShootCooldown;
    int _score;

    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        _maxShootCooldown = _playerStats.ShootCooldown;
        _currentShootCooldown = _maxShootCooldown;

        _playerStats.OnHPChange +=() => { StartCoroutine("UpdateHP"); };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentShootCooldown <= 0)
            Shoot();

        UpdateUI();
    }

    private void UpdateUI()
    {
        UpdateCooldown();
        UpdateCopperUI();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        ScoreText.text = $"{_playerStats.Score}";
        UpdateMinimapCameraPosition();
    }
    
    private void UpdateMinimapCameraPosition() => MinimapCamera.position = new Vector3(transform.position.x, transform.position.y, 0);
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

    private IEnumerator UpdateHP()
    {
        float _filledAmount = _playerStats.CurrentHP / _playerStats.MaxHealthPoints;

        GreenHPImage.fillAmount = _filledAmount;
        yield return new WaitForSeconds(0.5f);
        RedHPImage.fillAmount = _filledAmount;
    }

    private void UpdateCopperUI() => CopperText.text = $"{_playerStats.CopperCount}x";

    private void Shoot()
    {
        GameObject _bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        _bullet.GetComponent<Rigidbody2D>().AddForce(BulletSpawnPoint.up * _bullet.GetComponent<ProjectileBehavior>().ShootSpeed);

        GameManager.GameManagerInstance.PlaySound(GameManager.GameManagerInstance.ShootAudio);
        _currentShootCooldown = _maxShootCooldown;
    }
}