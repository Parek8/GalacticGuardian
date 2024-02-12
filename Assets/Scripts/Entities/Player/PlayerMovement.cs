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

        // LEFT
        if (Input.GetKey(KeyCode.A))
            transform.position = Vector3.MoveTowards(transform.position, -transform.right + transform.position, Time.deltaTime * _playerStats.MovementSpeed);
        // RIGHT
        if (Input.GetKey(KeyCode.D))
            transform.position = Vector3.MoveTowards(transform.position, transform.right + transform.position, Time.deltaTime * _playerStats.MovementSpeed );

        // ROTATE LEFT
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0, 0, 1 * _playerStats.RotationSpeed));
        // ROTATE RIGHT
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(new Vector3(0, 0, -1 * _playerStats.RotationSpeed));

    }
}