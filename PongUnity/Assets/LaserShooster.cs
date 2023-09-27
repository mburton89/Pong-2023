using UnityEngine;
using UnityEngine.UI;

public class LaserShooster : MonoBehaviour
{
    public LineRenderer laserLine;
    public Transform firePoint;
    public float maxDistance = 100f;

    private bool isFiring = false;

    public float maxLaserAmount = 1f;
    float currentLaserAmount;
    public float laserConsumptionRate;
    public float laserRegenRate;
    public Image laserAmountFill;
    bool isOverheated;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
            StartFiringLaser();
        }

        // Check for left mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
            StopFiringLaser();
        }

        if (isFiring)
        {
            FireLaser();
        }

        UpdateUI();
    }

    void StartFiringLaser()
    {
        laserLine.enabled = true;
    }

    void FireLaser()
    {
        Vector3 endPoint;

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            endPoint = hit.point;
            if (hit.transform.CompareTag("Mineral"))
            {
                hit.transform.gameObject.GetComponent<Minerals>().TakeDamage(0.05f);
            }
        }
        else
        {
            endPoint = ray.GetPoint(maxDistance);
        }

        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, endPoint);


    }

    void StopFiringLaser()
    {
        laserLine.enabled = false;
        currentLaserAmount -= laserConsumptionRate;
    }

    void UpdateUI()
    {
        laserAmountFill.fillAmount = (float)currentLaserAmount / (float)maxLaserAmount;
    }
}