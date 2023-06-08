using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMostBalls : MonoBehaviour
{
    public float totalTime = 0f;
    public float timeRemaining = 0f;
    //public bool timerIsRunning = false;

    [SerializeField] Text countdownText;
    public static TimerMostBalls Instance;

    private void Start()
    {
        //timerIsRunning = false;
        timeRemaining = totalTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= 1 * Time.deltaTime;
            countdownText.text = timeRemaining.ToString("0");
        }
        else
        {
            timeRemaining = 0;
            StartCoroutine(MostBallsManager.Instance.WinGame());
            //timerIsRunning = false;
        }
    }

    /*private void Awake()
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
                StartCoroutine(ShapesGameManager.Instance.WinGame());
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            timeRemaining = totalTime;
            timerIsRunning = false;
            DisplayTime(totalTime - 1);
            GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
            foreach (GameObject circle in circles)
                Destroy(circle);
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
            GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
            foreach (GameObject circle in circles)
                Destroy(circle);


        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        countdownText.text = timeRemaining.ToString("0");
        /*float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/
}
