using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Collider2D))]
internal class EntityStats : MonoBehaviour, IDeathObserver
{
    #region Stats
    [field: Header("Entity Parameters")]
    [field: SerializeField] public float MovementSpeed {get; protected set;} = 1; 
    [field: SerializeField] public float BoostMultiplier {get; protected set;} = 5; 
    [field: SerializeField] public float RotationSpeed {get; protected set;} = 1;
    [field: SerializeField] public float AttackDamage {get; protected set;} = 1;
    [field: SerializeField] public float Defense {get; protected set;} = 1;
    [field: SerializeField] public float MaxHealthPoints {get; protected set;} = 1;
    [field: SerializeField] public float MinimalDamageTaken {get; protected set;} = 1;
    [field: SerializeField] public List<DropBehaviour> DroppedCurrencies { get; protected set; } = new();

    [field: Header("Shoot Parameters")]
    [field: SerializeField] internal float ShootCooldown {get; private set;} = 1;
    #endregion

    #region InterfaceProperties
    List<ISubscriber> IDeathObserver.subscribers { get; set; } = new();
    #endregion

    float _currentHp;
    internal float CurrentHP => _currentHp;
    internal Action OnHPChange;

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
        OnHPChange?.Invoke();
    }

    void Heal(float amount)
    {
        if (_currentHp < MaxHealthPoints)
            _currentHp += amount;

        MaxHealthPoints += amount / 10;
        OnHPChange?.Invoke();
    }

    internal void BoostMovementSpeed()
    {
        if (!_isBoosted)
        {
            MovementSpeed *= BoostMultiplier;
            RotationSpeed *= BoostMultiplier;
            _isBoosted = true;    
        }
    }

    internal void RevertMovementSpeed()
    {
        if (_isBoosted)
        {
            MovementSpeed /= BoostMultiplier;
            RotationSpeed /= BoostMultiplier;
            _isBoosted = false;
        }
    }

    protected virtual void Die()
    {
        foreach (DropBehaviour _drop in DroppedCurrencies)
        {
            if (UnityEngine.Random.Range(0, 1f) >= _drop.DroppedCurrency.SpawnChance)
                Instantiate(_drop.gameObject, transform.position, Quaternion.identity);
        }

        ((IDeathObserver)this).Alert();
        Destroy(gameObject);
    }

    internal void IncreaseStat(StatType type, float value)
    {
        switch (type)
        {
            case StatType.AttackDamage:
                AttackDamage += value;
            break;

            case StatType.BoostMultiplier:
                BoostMultiplier += value;
                break;

            case StatType.RotationSpeed:
                RotationSpeed += value;
                break;

            case StatType.MovementSpeed:
                MovementSpeed += value;
                break;

            case StatType.Defense:
                Defense += value;
                break;

            case StatType.MaxHealthPoints:
                Heal(value);
                break;

            default:
                Debug.LogWarning("StatType not found!");
            break;
        }
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
internal enum StatType
{
    MovementSpeed,
    BoostMultiplier,
    RotationSpeed,
    AttackDamage,
    Defense,
    MaxHealthPoints
}