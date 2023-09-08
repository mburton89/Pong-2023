using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float jogSpeed;
    public float sprintSpeed;
    public float jumpHeight;
    public float mouseSensitivity;

    public GameObject miningLaser;
    public Rigidbody rb;
    public Transform camera;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
    }

    private void LateUpdate()
    {
        Vector3 e = camera.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        e.x = RestrictAngle(e.x, -85f, 85f);
        camera.eulerAngles = e;
    }


    void FixedUpdate()
    {
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : jogSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = transform.TransformDirection(newVelocity);
    }   

    void Move()
    {

    }

    void Jump()
    {

    }

    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        return angle;
    }


     
}
