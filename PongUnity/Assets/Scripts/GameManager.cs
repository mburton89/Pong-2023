using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ManagerTester tester;
    
    public int mineral1Count;
    public int mineral2Count;
    public int mineral3Count;
    public int mineral4Count;

    public TextMeshProUGUI mineral1Counter;
    public TextMeshProUGUI mineral2Counter;
    public TextMeshProUGUI mineral3Counter;
    public TextMeshProUGUI mineral4Counter;

    public Image chargeSliderBG;
    public Image ChargeSlider;
    public float usageRate;
    public float rechargeRate;

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
        ChargeSlider.fillAmount = 1;
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
        else if (ManagerTester.Instance.mineralType == "Mineral 3")
        {
            mineral3Count += ManagerTester.Instance.pointValue;
        }
        else if (ManagerTester.Instance.mineralType == "Mineral 4")
        {
            mineral4Count += ManagerTester.Instance.pointValue;
        }

        UpdateMineralCountUI();
    }

    // Updates the text in UI to the mineral count.
    public void UpdateMineralCountUI()
    {
        mineral1Counter.text = "M1: " + mineral1Count.ToString();
        mineral2Counter.text = "M2: " + mineral2Count.ToString();
        mineral3Counter.text = "M3: " + mineral3Count.ToString();
        mineral4Counter.text = "M4: " + mineral4Count.ToString();
    }

    public void UpdateGunChargeUI()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ChargeSlider.fillAmount -= usageRate;
        }
        else 
        { 
            ChargeSlider.fillAmount += rechargeRate;
        }

    }

    public void HandleOverheat()
    {

        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        chargeSliderBG.color = new Color(.5f, 0, 0);
        ChargeSlider.DOColor(Color.red, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.white, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.red, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.white, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.red, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.white, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.red, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.white, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.red, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.white, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.red, 0.25f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.25f);
        ChargeSlider.DOColor(Color.white, 0.25f).SetEase(Ease.InOutQuad);

        chargeSliderBG.color = Color.grey;
    }

    public void HandleOverheatComplete()
    {
        ChargeSlider.color = Color.white;
    }
}
