using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float totalTime;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    public Text timeText2;

    public static Timer Instance;
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
                StartCoroutine(ShapesGameManager.Instance.WinGame());
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            timeRemaining = totalTime;
            timerIsRunning = false;
            DisplayTime(totalTime - 1);
            GameObject[] shapes = GameObject.FindGameObjectsWithTag("Shape");
            foreach (GameObject shape in shapes)
                Destroy(shape);
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
            GameObject[] shapes = GameObject.FindGameObjectsWithTag("Shape");
            foreach (GameObject shape in shapes)
                Destroy(shape);


        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}