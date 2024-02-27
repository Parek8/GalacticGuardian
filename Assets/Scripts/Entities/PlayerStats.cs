using System;
using UnityEngine;

internal class PlayerStats : EntityStats, ISubscriber
{
    public int Score;
    internal int CopperCount;
    internal float CopperNeededForUpgrade = 10f;
    void ISubscriber.Alert()
    {
        throw new System.NotImplementedException();
    }
    
    internal void PickUpCopper() => this.CopperCount++;

    internal void RemoveCopper() => this.CopperCount--;

    internal void RemoveCopper(float Amount) => this.CopperCount-= (int)Amount;

    internal override void IncreaseStat(StatType type, float value)
    {
        base.IncreaseStat(type, value);
        RemoveCopper(CopperNeededForUpgrade);
        CopperNeededForUpgrade = (float)Math.Ceiling(1.2f * CopperNeededForUpgrade);
        GameManager.GameManagerInstance.DisableUpgradeUi();
    }
    protected override void Die()
    {
        ((IDeathObserver)this).Alert();
        Destroy(gameObject);
        Time.timeScale = 0;
        GameManager.GameManagerInstance.EnableGameOver();
    }
}