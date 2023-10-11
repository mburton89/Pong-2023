using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFront : MonoBehaviour
{
    public float proximityFromMouse;
    public Color minColor;  // The color when the mouse is far
    public Color maxColor;  // The color when the mouse is very close

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        // Map the distance to a color between minColor and maxColor
        Color lerpedColor = Color.Lerp(minColor, maxColor, Mathf.InverseLerp(0, proximityFromMouse, distance));
        spriteRenderer.color = lerpedColor;

        if (distance <= proximityFromMouse)
        {
            Debug.Log("Mouse is too close.");
        }
        else
        {
            Debug.Log(" All Goood");
        }
    }
}
