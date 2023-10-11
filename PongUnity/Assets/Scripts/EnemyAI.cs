using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIMouse : MonoBehaviour
{
    public float enemyMoveSpeed;
    public float proximityFromMouse;
    public float despawnDistance;  // The distance at which the enemy is despawned
    public float stopDistance;   // The distance at which the enemy stops moving
    public Color minColor;  // The color when the mouse is far
    public Color maxColor;  // The color when the mouse is very close

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        rb = GetComponent < Rigidbody2D>();
        spriteRenderer = GetComponent < SpriteRenderer>();
    }

    void Update()
    {
        // Get the current mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;

        // Convert the screen position to world position
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the enemy to the mouse
        Vector3 directionToMouse = mouseWorldPosition - transform.position;

        // Calculate the distance between the mouse and the enemy
        float distance = directionToMouse.magnitude;

        // Use the distance for further actions or logic
        Debug.Log("Distance to mouse: " + distance);

        // Map the distance to a color between minColor and maxColor
        Color lerpedColor = Color.Lerp(minColor, maxColor, Mathf.InverseLerp(0, proximityFromMouse, distance));
        spriteRenderer.color = lerpedColor;


        if (distance <= proximityFromMouse)
        {
            if (distance <= stopDistance)
            {
                stopRunningAway();
                Debug.Log("stop");
            }
            else
            {
                // Move away from the mouse if not too close
                runAway(directionToMouse.normalized);
                Debug.Log("go");

            }
        }

        // Despawn the enemy if it's too far from the mouse
        if (distance > despawnDistance)
        {
            Destroy(gameObject);  // Destroy the enemy if it's too far
            Debug.Log("despawn");

        }

        // Face the mouse cursor
        FaceMouse(directionToMouse.normalized);
    }

    void runAway(Vector3 direction)
    {
        rb.AddForce(-direction.normalized * enemyMoveSpeed);
    }

    void stopRunningAway()
    {
        rb.velocity = Vector2.zero;
    }

    void moveAwayFromMouse(Vector3 directionToMouse)
    {
        runAway(directionToMouse);
    }

    void FaceMouse(Vector3 direction)
    {
        // Make the enemy face opposite to the mouse direction
        transform.up = -direction;
    }
}