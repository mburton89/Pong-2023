using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange;
    public float laserCharge;
    public float maxLaserCharge = 50;
    public float laserRechargeRate = 1;
    public float laserDechargeRate = 1;
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

        if (laserCharge != maxLaserCharge && isFiringLaser == false)
        {
            laserCharge = laserCharge + (laserRechargeRate * Time.deltaTime);
        }

        else
        {
            if (Input.GetButton("Fire1"))
            {
                isFiringLaser = true; // Moved this line here
                laserLine.enabled = true; // Moved this line here
                FireMiningLaser();
            }

            if (Input.GetButtonUp("Fire1"))
            {
                isFiringLaser = false; // Moved this line here
                StopMiningLaser();
            }
        }

        if (laserCharge <= 0)
        {
            isFiringLaser = false;
            StopMiningLaser();
            gunRecharging = true;
            Debug.Log("Mining gun overheated");
        }

        if (laserCharge >= maxLaserCharge)
        {
            gunRecharging = false;
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
            print("fdhalisdgubil");
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserCharge = laserCharge - (laserDechargeRate * Time.deltaTime);
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
        laserCharge = 0f;
        Debug.Log("Laser Off");
    }

   /* IEnumerator RechargeGun()
    {
        yield return new WaitForSeconds(laserRechargeTime);
        gunRecharging = false;
        Debug.Log("Gun charged now");
    }
   */
}