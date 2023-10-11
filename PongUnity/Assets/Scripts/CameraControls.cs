using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float cameraMoveSpeed = 5.0f; // Adjust this value to control the camera movement speed

    private void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Check for WASD key inputs and set the move direction
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        // Normalize the move direction to ensure consistent speed in all directions
        moveDirection.Normalize();

        // Move the camera in the specified direction
        transform.position += moveDirection * cameraMoveSpeed * Time.deltaTime;
    }
}

