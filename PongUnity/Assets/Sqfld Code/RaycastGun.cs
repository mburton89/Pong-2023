using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastGun : MonoBehaviour
{
    public static RaycastGun Instance;

    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange;
    //public float maxLaserDuration; //TODO replace & remove
    public float laserRechargeTime;
    [HideInInspector] public bool isOverheated;

    LineRenderer laserLine;
    //private float fireTimer; //TODO replace & remove
    [HideInInspector] public bool isFiringLaser;

    public float maxLaserCharge = 1;
    public float currentLaserCharge;
    public float laserConsumptionRate;
    public float laserRechargeRate;

    public GameObject laserHitParticlesPrefab;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        StopMiningLaser();
        Instance = this;
    }

    private void Start()
    {
        currentLaserCharge = maxLaserCharge;
    }

    void Update()
    {
        if (isOverheated)
        {
            
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

        if (currentLaserCharge <= 0 && !isOverheated)
        {
            isFiringLaser = false;
            StopMiningLaser();
            isOverheated = true;
            Debug.Log("Mining gun overheated");
            StartCoroutine(RechargeGun());
        }

        // Update the laser position continuously
        if (isFiringLaser)
        {
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 endPoint = laserOrigin.position + (playerCamera.transform.forward * gunRange);
            laserLine.SetPosition(1, endPoint);
        }

        if (!isFiringLaser && currentLaserCharge < 1)
        {
            currentLaserCharge += laserRechargeRate * Time.deltaTime;
        }

        GameManager.Instance.ChargeSlider.fillAmount = currentLaserCharge;
    }

    public void FireMiningLaser()
    {
        if (!isOverheated)
        {
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            //fireTimer += Time.deltaTime;
            currentLaserCharge -= laserConsumptionRate * Time.deltaTime;
            if (Physics.Raycast(laserOrigin.position, playerCamera.transform.forward, out hit, gunRange))
            {
                if (hit.transform.CompareTag("Mineral"))
                {
                    //Destroy(hit.transform.gameObject);
                    //Debug.Log("Target Hit, Mineral destroyed.");
                    hit.transform.gameObject.GetComponent<Minerals>().TakeDamage(0.05f);
                    Instantiate(laserHitParticlesPrefab, hit.transform.position, Quaternion.identity, null);
                    //SoundManager.Instance.PlayLaserHitSound();
                }
                else
                {
                   //Debug.Log("target is not a mineral.");
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            //Debug.Log("Laser shot");
        }
    }

    public void StopMiningLaser()
    {
        laserLine.enabled = false;
        //fireTimer = 0f;
        isFiringLaser = false;
        Debug.Log("Laser Off");
    }

    IEnumerator RechargeGun()
    {
        GameManager.Instance.HandleOverheat();
        yield return new WaitForSeconds(laserRechargeTime);
        isOverheated = false;
        Debug.Log("Gun charged now");
        GameManager.Instance.HandleOverheatComplete();
    }
}