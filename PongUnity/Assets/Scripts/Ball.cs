using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 direction;
    public float maxXPosition;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBoundaries();
    }

    void Move()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    public void Bounce(Vector3 newDirection)
    { 
        direction = newDirection;
    }

    public void CheckBoundaries()
    {
        if (transform.position.x > maxXPosition || transform.position.x < -maxXPosition)
        {
            BallSpawner.Instance.SpawnBall();
            Destroy(gameObject);
        }
    }
}
