using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMostBalls : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 30f;
    //public bool timerIsRunning = false;

    [SerializeField] Text countdownText;
    public static TimerMostBalls Instance;

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
    }*/

    private void Start()
    {
        //timerIsRunning = false;
        currentTime = startingTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }
        else
        {
            currentTime = 0;
            //timerIsRunning = false;
        }
    }
}
