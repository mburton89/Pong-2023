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

    public TextMeshProUGUI mineralCounter;

    public float gunCharge;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMineralCountUI()
    {

    }

    public void UpdateGunChargeUI()
    {

    }

}
