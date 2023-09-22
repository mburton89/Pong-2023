using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ManagerTester tester;
    
    public int mineral1Count;
    public int mineral2Count;
    public int mineral3Count;

    public TextMeshProUGUI mineral1Counter;
    public TextMeshProUGUI mineral2Counter;
    public TextMeshProUGUI mineral3Counter;

    public Image ChargeSlider;
    public float usageRate;
    public float rechargeRate;

    public RaycastGun laserGun;

    // public float maxGunCharge;
    // public float currentGunCharge;
    // public bool isGunFiring = false;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateMineralCountUI();
        ChargeSlider.fillAmount = RaycastGun.Instance.maxLaserDuration;
        UpdateGunChargeUI();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateGunChargeUI();
    }

    // Checks mineral type when mined and adds to the count.
    public void TestMineralMined()
    {
       if (ManagerTester.Instance.mineralType == "Mineral 1")
        {
            mineral1Count += ManagerTester.Instance.pointValue;
        }
       else if (ManagerTester.Instance.mineralType == "Mineral 2")
        {
            mineral2Count += ManagerTester.Instance.pointValue;
        }

        UpdateMineralCountUI();
    }

    // Updates the text in UI to the mineral count.
    public void UpdateMineralCountUI()
    {
        mineral1Counter.text = "M1: " + mineral1Count.ToString();
        mineral2Counter.text = "M2: " + mineral2Count.ToString();
        mineral3Counter.text = "M3: " + mineral3Count.ToString();
    }

    public void UpdateGunChargeUI()
    {
        float fillAmount = 1 - (RaycastGun.Instance.fireTimer / RaycastGun.Instance.maxLaserDuration);
        fillAmount = Mathf.Clamp01(fillAmount);

        if (RaycastGun.Instance.isFiringLaser == true)
        {
            //ChargeSlider.fillAmount -= RaycastGun.Instance.fireTimer;
            ChargeSlider.fillAmount = fillAmount;

        }
        else 
        { 
        ChargeSlider.fillAmount += RaycastGun.Instance.maxLaserDuration;
        }

    }



}
