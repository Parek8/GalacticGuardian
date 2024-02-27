internal class PlayerStats : EntityStats, ISubscriber
{
    public int Score;
    internal int CopperCount;
    void ISubscriber.Alert()
    {
        throw new System.NotImplementedException();
    }
    
    internal void PickUpCopper() => this.CopperCount++;

    internal void RemoveCopper() => this.CopperCount--;

    protected override void Die()
    {
        ((IDeathObserver)this).Alert();
        Destroy(gameObject);
    }
}