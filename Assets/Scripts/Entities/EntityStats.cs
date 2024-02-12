using UnityEngine;

internal class EntityStats : MonoBehaviour
{
    [field: SerializeField] internal float MovementSpeed = 1;
    [field: SerializeField] internal float RotationSpeed = 1;
    [field: SerializeField] internal float AttackDamage = 1;
    [field: SerializeField] internal float Defense = 1;
    [field: SerializeField] internal float MaxHealthPoints = 1;
}