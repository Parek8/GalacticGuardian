using System;
using UnityEngine;

[RequireComponent(typeof(EntityStats))]
internal class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] private Transform MinimapBackground;

    EntityStats _playerStats;
    private void Start()
    {
        _playerStats = GetComponent<EntityStats>();
        GameManager.GameManagerInstance.PlaySound(GameManager.GameManagerInstance.FlyingAudio);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        GameManager.GameManagerInstance.FlyingAudio.volume = 0.1f;
        // UP
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.up + transform.position, Time.deltaTime * _playerStats.MovementSpeed);
            GameManager.GameManagerInstance.FlyingAudio.volume = 1f;
        }
        // DOWN
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = Vector3.MoveTowards(transform.position, -transform.up + transform.position, Time.deltaTime * _playerStats.MovementSpeed);
            GameManager.GameManagerInstance.FlyingAudio.volume = 1f;
        }

        // ROTATE LEFT
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1 * _playerStats.RotationSpeed));
            MinimapBackground.Rotate(new Vector3(0, 0, -1 * _playerStats.RotationSpeed));
            GameManager.GameManagerInstance.FlyingAudio.volume = 1f;
        }
        // ROTATE RIGHT
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -1 * _playerStats.RotationSpeed));
            MinimapBackground.Rotate(new Vector3(0, 0, 1 * _playerStats.RotationSpeed));
            GameManager.GameManagerInstance.FlyingAudio.volume = 1f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
            _playerStats.BoostMovementSpeed();
        else
            _playerStats.RevertMovementSpeed();
    }
}