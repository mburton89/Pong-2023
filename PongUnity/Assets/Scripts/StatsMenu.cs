using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    public static StatsMenu Instance;

    public GameManager GameManager;
    
    public TextMeshProUGUI mineral1Total;
    public TextMeshProUGUI mineral2Total;
    public TextMeshProUGUI mineral3Total;
    public TextMeshProUGUI mineralTotal;

    public TextMeshProUGUI bestScore;

    public TextMeshProUGUI mineral1Count;
    public TextMeshProUGUI mineral2Count;
    public TextMeshProUGUI mineral3Count;

    public Button retryButton;
    public GameObject statsMenu;

    public int intMineral1Total;
    public int intMineral2Total;
    public int intMineral3Total;
    public int intMineralTotalCount;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(RetryButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateMineralScore();
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void UpdateMineralScore()
    {
        mineral1Count.text = GameManager.mineral1Count.ToString();
        mineral2Count.text = GameManager.mineral2Count.ToString();
        mineral3Count.text = GameManager.mineral3Count.ToString();

        intMineral1Total = GameManager.mineral1Count * 100;
        intMineral2Total = GameManager.mineral2Count * 200;
        intMineral3Total = GameManager.mineral3Count * 300;

        mineral1Total.text = intMineral1Total.ToString();
        mineral2Total.text = intMineral2Total.ToString();
        mineral3Total.text = intMineral3Total.ToString();

        intMineralTotalCount = intMineral1Total + intMineral2Total + intMineral3Total;
        mineralTotal.text = intMineralTotalCount.ToString();

        if (intMineralTotalCount > PlayerPrefs.GetInt("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", intMineralTotalCount);
            bestScore.text = "New Best Score: " + PlayerPrefs.GetInt("bestscore").ToString();
            bestScore.color = Color.red;
        }
        else
        { 
            bestScore.text = "Best Score: " + PlayerPrefs.GetInt("bestscore").ToString();
        }

    }

    void RetryButtonPressed()
    {
        Debug.Log("here I go again.");
        statsMenu.SetActive(false);
        SceneTransition.Instance.TransitionToScene(1);
    }

    public void HandleTimerEnd()
    {
        UpdateMineralScore();

        FindAnyObjectByType<PlayerControllerScript>().enabled = false;
        FindAnyObjectByType<RaycastGun>().enabled = false;

        statsMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}