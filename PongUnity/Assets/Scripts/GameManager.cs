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

    public TextMeshProUGUI pointText;
/*    public TextMeshProUGUI mineral2Counter;
    public TextMeshProUGUI mineral3Counter;
    public TextMeshProUGUI mineral4Counter;*/

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
        Application.targetFrameRate = 60;
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
            mineral1Count += 100;
        }
       else if (ManagerTester.Instance.mineralType == "Mineral 2")
        {
            mineral1Count += 200;
        }
        else if (ManagerTester.Instance.mineralType == "Mineral 3")
        {
            mineral1Count += 300;
        }
        else if (ManagerTester.Instance.mineralType == "Mineral 4")
        {
            mineral1Count += 100;
        }

        UpdateMineralCountUI();
    }

    // Updates the text in UI to the mineral count.
    public void UpdateMineralCountUI()
    {
        int totalMineral1Points = mineral1Count * 100;
        int totalMineral2Points = mineral2Count * 200;
        int totalMineral3Points = mineral3Count * 300;
        int totalMineral4Points = mineral4Count * 100;
        int totalPoints = totalMineral1Points + totalMineral2Points + totalMineral3Points + totalMineral4Points;

        pointText.text = totalPoints.ToString();
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
