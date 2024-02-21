using UnityEngine;

[RequireComponent(typeof(EntityStats))]
internal class PlayerMovement : MonoBehaviour
{
    EntityStats _playerStats;
    private void Start()
    {
        _playerStats = GetComponent<EntityStats>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // UP
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.position = Vector3.MoveTowards(transform.position, transform.up + transform.position, Time.deltaTime * _playerStats.MovementSpeed);
        // DOWN
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.position = Vector3.MoveTowards(transform.position, -transform.up + transform.position, Time.deltaTime * _playerStats.MovementSpeed);

        // ROTATE LEFT
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0, 0, 1 * _playerStats.RotationSpeed));
        // ROTATE RIGHT
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(new Vector3(0, 0, -1 * _playerStats.RotationSpeed));

        if (Input.GetKey(KeyCode.LeftShift))
            _playerStats.BoostMovementSpeed();
        else
            _playerStats.RevertMovementSpeed();

    }
}