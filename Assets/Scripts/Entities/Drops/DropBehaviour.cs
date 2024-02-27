using UnityEngine;

public class DropBehaviour : MonoBehaviour
{
    [field: SerializeField] internal float MovementSpeed { get; private set;}
    [field: SerializeField] internal Currency DroppedCurrency { get; private set;}

    Transform _playerTransform;
    void Start()
    {
        _playerTransform = GameManager.GameManagerInstance.PlayerTransform;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, Time.deltaTime * MovementSpeed);

        if (Vector2.Distance(transform.position, _playerTransform.position) <= 0.3f)
        {
            GameManager.GameManagerInstance.PlayerStats.PickUpCopper();
            Destroy(gameObject);
        }
    }
}