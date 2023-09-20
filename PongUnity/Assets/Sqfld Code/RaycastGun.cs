using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange;
    public float maxLaserDuration;
    public float laserRechargeTime;
    private bool gunRecharging;

    LineRenderer laserLine;
    private float fireTimer;
    private float rechargeTimer;
    private bool isFiringLaser;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();    
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        rechargeTimer += Time.deltaTime;


        if (gunRecharging)
        {
            RechargeGun();
            Debug.Log("Gun isn't charged");
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                isFiringLaser = true; // Moved this line here
                laserLine.enabled = true; // Moved this line here
                FireMiningLaser();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isFiringLaser = false; // Moved this line here
            StopMiningLaser();
        }

        if (fireTimer >= maxLaserDuration)
        {
            isFiringLaser = false;
            StopMiningLaser();
            Debug.Log("Mining gun overheated");
            gunRecharging = true;
            rechargeTimer = 0f;
        }

        // Update the laser position continuously
        if (isFiringLaser)
        {
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 endPoint = laserOrigin.position + (playerCamera.transform.forward * gunRange);
            laserLine.SetPosition(1, endPoint);
        }


        //if (Input.GetButtonDown("Fire2") && fireTimer > fireRate)
        //{
        //Vacuum Mode
        //}
    }

    public void FireMiningLaser()
    {
        if (!gunRecharging)
        {
            fireTimer = 0f;
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(laserOrigin.position, playerCamera.transform.forward, out hit, gunRange))
            {
                if (hit.transform.CompareTag("Mineral"))
                {
                    Destroy(hit.transform.gameObject);
                    Debug.Log("Target Hit, Mineral destroyed.");
                }
                else
                {
                    Debug.Log("target is not a mineral.");
                }
            }
        }
    }

    public void StopMiningLaser()
    {
        laserLine.enabled = false;
        Debug.Log("Laser Off");
    }

    public void RechargeGun()
    {
        if (rechargeTimer >= laserRechargeTime)
        {
            gunRecharging = false;
        }
    }
}
