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
        Debug.Log(gunRecharging);
        if (Input.GetMouseButtonDown(0) && laserCharge != 0f)
        {
            isFiringLaser = true; // Moved this line here
            laserLine.enabled = true; // Moved this line here
            FireMiningLaser();
        }


        if (Input.GetMouseButtonUp(0) && isFiringLaser == true)
        {
            Debug.Log("daghbgibgofagbo");
            isFiringLaser = false; // Moved this line here
            StopMiningLaser();
        }

        if (laserCharge != maxLaserCharge && isFiringLaser == false)
        {
            laserCharge = laserCharge + (laserRechargeRate * Time.deltaTime);
        }

        if (laserCharge <= 0 || Input.GetMouseButtonUp(0))
        {
            isFiringLaser = false;
            StopMiningLaser();
            gunRecharging = true;
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
        if (laserCharge > 0f)
        {
            Debug.Log("fdhalisdgubil");
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserCharge = laserCharge - (laserDechargeRate * Time.deltaTime);
            if (Physics.Raycast(laserOrigin.position, playerCamera.transform.forward, out hit, gunRange))
            {
                if (hit.transform.CompareTag("Mineral"))
                {
                    //Destroy(hit.transform.gameObject);
                    //Debug.Log("Target Hit, Mineral destroyed.");
                    //hit.transform.gameObject.GetComponent<Minerals>().TakeDamage(0.05f);
                }
                else
                {
                   //Debug.Log("target is not a mineral.");
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
                gunRecharging = false;
                //Debug.Log("Target ");
            }
            //Debug.Log("Laser shot");
        }
    }

    public void StopMiningLaser()
    {
        laserLine.enabled = false;
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