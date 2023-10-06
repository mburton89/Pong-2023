using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSquirm : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of movement
    public float changeDirectionInterval = 3.0f; // Time interval to change direction
    private float nextDirectionChangeTime;

    private void Start()
    {
        nextDirectionChangeTime = Time.time + Random.Range(0, changeDirectionInterval);
    }

    private void Update()
    {
        if (Time.time >= nextDirectionChangeTime)
        {
            ChangeDirection();
        }

        Move();
    }

    private void ChangeDirection()
    {
        // Generate a random direction vector
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        randomDirection.Normalize();

        // Set the object's rotation to face the new direction
        transform.rotation = Quaternion.LookRotation(randomDirection);

        // Set the next direction change time
        nextDirectionChangeTime = Time.time + changeDirectionInterval;
    }

    private void Move()
    {
        // Move the object forward
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
