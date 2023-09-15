using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                laserLine.enabled = false;
                Debug.Log("Laser Off");
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
            Destroy(hit.transform.gameObject);
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
        }
        Debug.Log("Laser shot");
    }

}
