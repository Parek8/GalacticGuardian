using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
internal class EntityStats : MonoBehaviour, IDeathObserver
{

    #region Stats
    [field: Header("Entity Parameters")]
    [field: SerializeField] internal float MovementSpeed {get; private set;} = 1; 
    [field: SerializeField] internal float BoostMultiplier {get; private set;} = 5; 
    [field: SerializeField] internal float RotationSpeed {get; private set;} = 1;
    [field: SerializeField] internal float AttackDamage {get; private set;} = 1;
    [field: SerializeField] internal float Defense {get; private set;} = 1;
    [field: SerializeField] internal float MaxHealthPoints {get; private set;} = 1;
    [field: SerializeField] internal float MinimalDamageTaken {get; private set;} = 1;
    [field: SerializeField] internal List<DropBehaviour> DroppedCurrencies { get; private set; } = new();

    [field: Header("Shoot Parameters")]
    [field: SerializeField] internal float ShootCooldown {get; private set;} = 1;
    #endregion

    #region InterfaceProperties
    List<ISubscriber> IDeathObserver.subscribers { get; set; }
    #endregion

    float _currentHp;
    bool _isBoosted = false;
    private void Start() 
    {
        _currentHp = MaxHealthPoints;
    }

    internal void TakeDamage(float takenDamage)
    {
        this._currentHp -= (takenDamage - this.Defense <= 0) ? MinimalDamageTaken : (takenDamage - this.Defense);

        if (_currentHp <= 0)
            Die();
    }

    internal void BoostMovementSpeed()
    {
        if (!_isBoosted)
        {
            MovementSpeed *= BoostMultiplier;
            _isBoosted = true;    
        }
    }

    internal void RevertMovementSpeed()
    {
        if (_isBoosted)
        {
            MovementSpeed /= BoostMultiplier;
            _isBoosted = false;
        }
    }

    private void Die()
    {
        foreach (DropBehaviour _drop in DroppedCurrencies)
        {
            if (Random.Range(0, 1f) >= _drop.DroppedCurrency.SpawnChance)
                Instantiate(_drop.gameObject);
        }

        ((IDeathObserver)this).Alert();
        Destroy(gameObject);
    }

    #region InterfaceImplementations
    void IDeathObserver.Subscribe(ISubscriber subscriber)
    {
        ((IDeathObserver)this).subscribers.Add(subscriber);
    }

    void IDeathObserver.Unsubscribe(ISubscriber subscriber)
    {
        ((IDeathObserver)this).subscribers.Remove(subscriber);
    }

    void IDeathObserver.Alert()
    {
        foreach(ISubscriber sub in ((IDeathObserver)this).subscribers)
            sub.Alert();
    }
    #endregion
}