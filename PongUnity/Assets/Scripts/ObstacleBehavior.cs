using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public void HandleCollision()
    {
        Debug.Log("Collision Detected");
        Destroy(gameObject);
    }
}