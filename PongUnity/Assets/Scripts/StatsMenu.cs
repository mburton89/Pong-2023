using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    public static StatsMenu Instance;

    public GameManager GameManager;

    public GameObject mineral1Container;
    public GameObject mineral2Container;
    public GameObject mineral3Container;
    public GameObject mineral4Container;
    public GameObject totalContainer;
    public GameObject bottomContainer;

    public AudioSource menuSound;

    public TextMeshProUGUI mineral1Total;
    public TextMeshProUGUI mineral2Total;
    public TextMeshProUGUI mineral3Total;
    public TextMeshProUGUI mineral4Total;
    public TextMeshProUGUI mineralTotal;

    public TextMeshProUGUI bestScore;

    public TextMeshProUGUI mineral1Count;
    public TextMeshProUGUI mineral2Count;
    public TextMeshProUGUI mineral3Count;
    public TextMeshProUGUI mineral4Count;

    public Button retryButton;
    public GameObject statsMenu;

    public int intMineral1Total;
    public int intMineral2Total;
    public int intMineral3Total;
    public int intMineral4Total;
    public int intMineralTotalCount;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(RetryButtonPressed);
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
        {
            Debug.LogWarning("PLAYER PREFS DELETED");
            PlayerPrefs.DeleteAll();
        }
    }

    private void UpdateMineralScore()
    {
        mineral1Count.text = GameManager.mineral1Count.ToString();
        mineral2Count.text = GameManager.mineral2Count.ToString();
        mineral3Count.text = GameManager.mineral3Count.ToString();
        mineral4Count.text = GameManager.mineral4Count.ToString();

        intMineral1Total = GameManager.mineral1Count * 100;
        intMineral2Total = GameManager.mineral2Count * 200;
        intMineral3Total = GameManager.mineral3Count * 300;
        intMineral4Total = GameManager.mineral4Count * 100;

        mineral1Total.text = intMineral1Total.ToString();
        mineral2Total.text = intMineral2Total.ToString();
        mineral3Total.text = intMineral3Total.ToString();
        mineral4Total.text = intMineral4Total.ToString();

        intMineralTotalCount = intMineral1Total + intMineral2Total + intMineral3Total + intMineral4Total;
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

        StartCoroutine(ShowStats());
    }

    void RetryButtonPressed()
    {
        SoundManager.Instance.PlayButtonSelectSound();

        Debug.Log("here I go again.");
        //statsMenu.SetActive(false);
        SceneTransition.Instance.TransitionToScene(1);
    }

    private IEnumerator ShowStats() 
    {
        menuSound.pitch = 0.7f;
        menuSound.Play();
        yield return new WaitForSeconds(.1f);
        mineral1Container.SetActive(true);
        menuSound.pitch = 0.8f;
        menuSound.Play();
        yield return new WaitForSeconds(.1f);
        mineral2Container.SetActive(true);
        menuSound.pitch = 0.9f;
        menuSound.Play();
        yield return new WaitForSeconds(.1f);
        mineral3Container.SetActive(true);
        menuSound.pitch = 1.0f;
        menuSound.Play();
        yield return new WaitForSeconds(.1f);
        mineral4Container.SetActive(true);
        menuSound.pitch = 1.1f;
        menuSound.Play();
        yield return new WaitForSeconds(.1f);
        totalContainer.SetActive(true);
        menuSound.pitch = 1.2f;
        menuSound.Play();
        yield return new WaitForSeconds(.2f);
        bottomContainer.SetActive(true);
        menuSound.pitch = 1.3f;
        menuSound.Play();
    }

    public void HandleTimerEnd()
    {
        FindAnyObjectByType<PlayerControllerScript>().enabled = false;
        FindAnyObjectByType<RaycastGun>().isFiringLaser = false;
        FindAnyObjectByType<RaycastGun>().enabled = false;
        FindAnyObjectByType<AudioManager>().GetComponent<AudioSource>().volume = 0f;

        statsMenu.SetActive(true);
        UpdateMineralScore();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}