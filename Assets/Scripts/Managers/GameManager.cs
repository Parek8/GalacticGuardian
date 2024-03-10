using System;
using System.Collections.Generic;
using UnityEngine;

internal sealed class GameManager : MonoBehaviour
{
    private static GameManager _gameManagerInstance;
    internal static GameManager GameManagerInstance => _gameManagerInstance;
    [field: SerializeField] internal Transform PlayerTransform;
    [field: SerializeField] internal PlayerStats PlayerStats;
    
    [field: SerializeField] internal GameObject UpgradeMenu;
    [field: SerializeField] internal GameObject GameOverMenu;
    [field: SerializeField] internal List<GameObject> HUD;
    [field: SerializeField] internal AudioSource BackgroundAudio;
    [field: SerializeField] internal AudioSource ShootAudio;
    [field: SerializeField] internal List<AudioSource> BlowAudioList;
    [field: SerializeField] internal AudioSource RandomBlowAudio => BlowAudioList[UnityEngine.Random.Range(0, BlowAudioList.Count)];
    [field: SerializeField] internal AudioSource FlyingAudio;
    [field: SerializeField] internal AudioListener PlayerAudioListener;

    private void Awake()
    {
        if (_gameManagerInstance == null)
            _gameManagerInstance = this;
    }

    private void Start()
    {
        PlaySound(BackgroundAudio);    
    }

    public void CheckIfPlayerCanUpgrade()
    {
        if(PlayerStats.CopperCount >= PlayerStats.CopperNeededForUpgrade && !UpgradeMenu.activeInHierarchy)
        {
            SetHUDActive(false);
            UpgradeMenu.SetActive(true);
            UpgradeMenu.GetComponent<CardUI>().RerollCards();
        }
    }

    void SetHUDActive(bool active)
    {
        foreach (GameObject _HUD in HUD)
            _HUD.SetActive(active);
    }

    public void DisableUpgradeUi()
    {
        SetHUDActive(true);
        UpgradeMenu.SetActive(false);
    }
    public void EnableGameOver()
    {
        StopSounds();
        GameOverMenu.SetActive(true);
        SetHUDActive(false);
        Time.timeScale = 0;
    }

    internal void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
    internal void StopSounds() => PlayerAudioListener.gameObject.SetActive(false);
}