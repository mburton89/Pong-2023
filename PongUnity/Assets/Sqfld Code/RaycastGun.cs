using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange;
    //public float fireRate;
   // public float laserDuration;

    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();    
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            FireMiningLaser();
        }
        else
        {
            if (Input.GetButtonUp("Fire1"))
            {
                StopMiningLaser();
            }
        }

        //if (Input.GetButtonDown("Fire2") && fireTimer > fireRate)
        //{
            //Vacuum Mode
        //}
    }

    public void FireMiningLaser()
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            if (GameObject.FindWithTag("Mineral"))
            {
                Destroy(hit.transform.gameObject);
                Debug.Log("Target Hit, Mineral destroyed.");
            }
            else
            {
                Debug.Log("target is not a mineral.");
            }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            Debug.Log("Target ");
        }
        Debug.Log("Laser shot");
    }

    public void StopMiningLaser()
    {
        laserLine.enabled = false;
        Debug.Log("Laser Off");
    }

}
