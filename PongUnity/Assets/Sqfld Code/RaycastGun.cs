using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange;
    private bool gunRecharging;

    LineRenderer laserLine;

    public float maxLaserAmount = 1f;
    float currentLaserAmount;
    public float laserConsumptionRate;
    public float laserRegenRate;
    public Image laserAmountFill;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();  
    }

    private void Start()
    {
        currentLaserAmount = maxLaserAmount;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") )
        {
            FireMiningLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopMiningLaser();
        }
    }

    public void FireMiningLaser()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Physics.Raycast(laserOrigin.position, playerCamera.transform.forward, out hit, gunRange);

        if (hit.transform.CompareTag("Mineral"))
        {
            hit.transform.gameObject.GetComponent<Minerals>().TakeDamage(0.05f);
        }

        //laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
        laserLine.enabled = true; // Moved this line here
        laserLine.SetPosition(0, laserOrigin.localPosition);
        Vector3 endPoint = laserOrigin.position + (playerCamera.transform.forward * gunRange);
        laserLine.SetPosition(1, endPoint);
    }

    public void StopMiningLaser()
    {
        laserLine.enabled = false;
    }
}