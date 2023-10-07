using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public StatsMenu statsMenu;

    public float timeLimit = 30f;
    private float currentTime;

    bool hasEndedTimer = false;

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        if (hasEndedTimer) return;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("F1");

            if (currentTime < 10)
            { 
                timerText.color = Color.red;
            }
        }
        else
        {
            timerText.color = Color.white;
            hasEndedTimer = true;
            Debug.Log("Timer has reached zero");
            statsMenu.HandleTimerEnd();
        }
    }
}

