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
        if (gunRecharging)
        {
            RechargeGun();
            Debug.Log("Gun isn't charged");
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                FireMiningLaser();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopMiningLaser();
        }

        if (isFiringLaser)
        {
            if(fireTimer >= maxLaserDuration)
            {
                StopMiningLaser();
                Debug.Log("Mining gun overheated");
            }
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
            laserLine.enabled = true;
            laserLine.SetPosition(0, laserOrigin.position);
            isFiringLaser = true;
            fireTimer = 0f;
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
                isFiringLaser = false;
                Debug.Log("Target ");
            }

            if (fireTimer >= maxLaserDuration)
            {
                StopMiningLaser();
                Debug.Log("Mining gun overheated");
            }
            Debug.Log("Laser shot");
        }
    }

    public void StopMiningLaser()
    {
        laserLine.enabled = false;
        Debug.Log("Laser Off");
    }

    public void RechargeGun()
    {
        rechargeTimer += Time.deltaTime;
        if (rechargeTimer >= laserRechargeTime)
        {
            gunRecharging = false; 
        }
    }
}
