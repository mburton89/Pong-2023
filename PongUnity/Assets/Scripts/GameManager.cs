using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int mineral1Count;
    public int mineral2Count;
    public int mineral3Count;

    public TextMeshProUGUI mineral1Counter;
    public TextMeshProUGUI mineral2Counter;
    public TextMeshProUGUI mineral3Counter;

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
        //UpdateGunChargeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Checks mineral type when mined and adds to the count.
    public void MineralMined()
    {
        // if (mineral.mineralType == "Mineral 1")
        {
            // mineral1Count += mineral.pointValue;
        }
    }

    // Updates the text in UI to the mineral count.
    public void UpdateMineralCountUI()
    {
        mineral1Counter.text = "Mineral 1: " + mineral1Count.ToString();
        mineral2Counter.text = "Mineral 2: " + mineral2Count.ToString();
        mineral3Counter.text = "Mineral 3: " + mineral3Count.ToString();
    }

    public void UpdateGunChargeUI()
    {

    }

}
