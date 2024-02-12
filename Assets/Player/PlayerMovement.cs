using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // UP
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.position = Vector3.MoveTowards(transform.position, transform.up + transform.position, Time.deltaTime /* * _stats.MovementSpeed */);
        // DOWN
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.position = Vector3.MoveTowards(transform.position, -transform.up + transform.position, Time.deltaTime /* * _stats.MovementSpeed */);

        // LEFT
        if (Input.GetKey(KeyCode.A))
            transform.position = Vector3.MoveTowards(transform.position, -transform.right + transform.position, Time.deltaTime /* * _stats.MovementSpeed */);
        // RIGHT
        if (Input.GetKey(KeyCode.D))
            transform.position = Vector3.MoveTowards(transform.position, transform.right + transform.position, Time.deltaTime /* * _stats.MovementSpeed */);

        // ROTATE LEFT
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0, 0, 1));
        // ROTATE RIGHT
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(new Vector3(0, 0, -1));

    }
}