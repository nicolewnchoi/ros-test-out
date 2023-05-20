using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMostBalls : MonoBehaviour
{
    public float totalTime;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;

    public static TimerMostBalls Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        timerIsRunning = false;
        timeRemaining = totalTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (timerIsRunning)
            {
                timerIsRunning = false;
            }
            else
            {
                timerIsRunning = true;
            }
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                StartCoroutine(MostBallsManager.Instance.WinGame());
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            timeRemaining = totalTime;
            timerIsRunning = false;
            DisplayTime(totalTime - 1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timerIsRunning)
            {
                timerIsRunning = false;
            }
            else
            {
                timerIsRunning = true;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{00}:{30}", seconds);
    }
}
