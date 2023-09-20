using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [Header("Configuration")]

    public float jogSpeed;
    public float sprintSpeed;
    public float jumpSpeed;
    public float mouseSensitivity;
    public Vector3 gunSocket;
    public GameObject laserClass;

    [Header("References")]

    public GameObject miningLaser;
    public Rigidbody rb;
    public Transform camera;

    [Header("Runtime")]

    Vector3 newVelocity;
    bool isGrounded = false;
    bool isJumping= false;
    bool jumpKeyDown;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        miningLaser = Instantiate(laserClass, this.transform);
        miningLaser.transform.position = gunSocket;
        if (miningLaser != null)
        {
            RaycastGun raycastGun = miningLaser.GetComponent<RaycastGun>();

            raycastGun.playerCamera = this.gameObject.transform.GetChild(0).GetComponent<Camera>();
        }
        
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    jumpKeyDown = Input.GetKeyDown(KeyCode.Space);
        //}

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);

        newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : jogSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        print("isGrounded: " + isGrounded);
        print("isJumping: " + isJumping);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                print("TRY JUMP");
                newVelocity.y = jumpSpeed;
                isJumping = true;
            }
            //Debug.Log(Input.GetKeyDown(KeyCode.Space));
        }

        rb.velocity = transform.TransformDirection(newVelocity);
        
        Vector3 e = camera.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        e.x = RestrictAngle(e.x, -85f, 85f);
        camera.eulerAngles = e;
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

    void OnCollisionStay(Collision col)
    {
        isGrounded = true;
        isJumping = false;
        //Debug.Log("Stay" + isGrounded);
    }

    void OnCollisionExit(Collision col)
    {
        isGrounded = false;
        //Debug.Log("Exit");
    }
     
}
