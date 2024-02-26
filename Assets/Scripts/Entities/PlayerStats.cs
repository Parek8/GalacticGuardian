internal class PlayerStats : EntityStats, ISubscriber
{
    public int Score;
    void ISubscriber.Alert()
    {
        throw new System.NotImplementedException();
    }
}