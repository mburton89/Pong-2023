using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float verticalMovementSpeed;
    public float maxYposition;
    public KeyCode upKey;
    public KeyCode downKey;
    public int ballHitXDirection;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey) && transform.position.y < maxYposition)
        {
            MoveUp();
        }
        else if (Input.GetKey(downKey) && transform.position.y > -maxYposition)
        {
            MoveDown();
        }
    }

    public void MoveUp()
    {
        transform.position += Vector3.up * verticalMovementSpeed * Time.deltaTime;
    }

    public void MoveDown()
    {
        transform.position += Vector3.down * verticalMovementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            float yHitDirection = (collision.transform.position.y - transform.position.y);
            Vector3 hitDirection = new Vector3(ballHitXDirection, yHitDirection, 0);
            collision.gameObject.GetComponent<Ball>().Bounce(hitDirection);
        }
    }
}
