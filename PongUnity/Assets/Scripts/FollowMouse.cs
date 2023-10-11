using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public LayerMask obstacleLayer; // Assign the layer with obstacles in the Inspector

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        CheckForObstacle();
    }

    void CheckForObstacle()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.1f, obstacleLayer);

        if (hit != null)
        {
            ObstacleBehavior obstacle = hit.gameObject.GetComponent<ObstacleBehavior>();
            if (obstacle != null)
            {
                obstacle.HandleCollision();
            }
        }
    }
}