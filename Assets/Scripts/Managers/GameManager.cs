using System;
using UnityEngine;

internal sealed class GameManager : MonoBehaviour
{
    private static GameManager _gameManagerInstance;
    internal static GameManager GameManagerInstance => _gameManagerInstance;
    [field: SerializeField] internal Transform PlayerTransform;
    [field: SerializeField] internal PlayerStats PlayerStats;
    
    [field: SerializeField] internal GameObject upgradeMenu;
    [field: SerializeField] internal GameObject GameOverMenu;
    private void Awake()
    {
        if (_gameManagerInstance == null)
            _gameManagerInstance = this;
    }

    public void CheckIfPlayerCanUpgrade()
    {
        if(PlayerStats.CopperCount >= PlayerStats.CopperNeededForUpgrade && upgradeMenu.active == false)
        {
            upgradeMenu.SetActive(true);
            upgradeMenu.GetComponent<CardUI>().RerollCards();
        }
    }
    public void DisableUpgradeUi()
    {
        upgradeMenu.SetActive(false);
    }
    public void EnableGameOver()
    {
        GameOverMenu.SetActive(true);
    }
}