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
    private bool isFiringLaser;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();  
    }

    void Update()
    {
        if (gunRecharging)
        {
            StartCoroutine(RechargeGun());
            Debug.Log("Gun isn't charged");
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                isFiringLaser = true;
                laserLine.enabled = true;
                FireMiningLaser();
            }

            if (Input.GetButtonUp("Fire1"))
            {
                isFiringLaser = false;
                StopMiningLaser();
            }

            // Calculate the laser endpoint continuously
            Vector3 endPoint = laserOrigin.position + (playerCamera.transform.forward * gunRange);
            laserLine.SetPosition(0, laserOrigin.position);
            laserLine.SetPosition(1, endPoint);
        }

        if (fireTimer >= maxLaserDuration)
        {
            isFiringLaser = false;
            StopMiningLaser();
            gunRecharging = true;
            Debug.Log("Mining gun overheated");
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
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            fireTimer += Time.deltaTime;
            if (Physics.Raycast(laserOrigin.position, playerCamera.transform.forward, out hit, gunRange))
            {
                if (hit.transform.CompareTag("Mineral"))
                {
                    //Destroy(hit.transform.gameObject);
                    //Debug.Log("Target Hit, Mineral destroyed.");
                    hit.transform.gameObject.GetComponent<Minerals>().TakeDamage(0.05f);
                }
                else
                {
                   //Debug.Log("target is not a mineral.");
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
                isFiringLaser = false;
                //Debug.Log("Target ");
            }
            //Debug.Log("Laser shot");
        }
    }

    public void StopMiningLaser()
    {
        laserLine.enabled = false;
        fireTimer = 0f;
        Debug.Log("Laser Off");
    }

    IEnumerator RechargeGun()
    {
        yield return new WaitForSeconds(laserRechargeTime);
        gunRecharging = false;
        Debug.Log("Gun charged now");
    }
}