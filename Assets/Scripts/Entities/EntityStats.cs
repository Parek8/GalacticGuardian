using UnityEngine;

[RequireComponent(typeof(Collider2D))]
internal class EntityStats : MonoBehaviour
{
    [field: Header("Entity Parameters")]
    [field: SerializeField] internal float MovementSpeed {get; private set;} = 1; 
    [field: SerializeField] internal float BoostMultiplier {get; private set;} = 5; 
    [field: SerializeField] internal float RotationSpeed {get; private set;} = 1;
    [field: SerializeField] internal float AttackDamage {get; private set;} = 1;
    [field: SerializeField] internal float Defense {get; private set;} = 1;
    [field: SerializeField] internal float MaxHealthPoints {get; private set;} = 1;
    [field: SerializeField] internal float MinimalDamageTaken {get; private set;} = 1;
    [field: Header("Shoot Parameters")]
    [field: SerializeField] internal float ShootCooldown {get; private set;} = 1;
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
        // IOBSERVER WILL SEND UPDATE ABOUT DEATH
        Destroy(gameObject);
    }
}