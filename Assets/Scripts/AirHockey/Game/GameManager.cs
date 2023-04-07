using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public int[] scores = new int[2];
    private Coroutine currentOpeningCoroutine;
    [SerializeField] Text scoreLeft;
    [SerializeField] Text scoreRight;
    [SerializeField] GameObject crownLeft;
    [SerializeField] GameObject crownRight;

    public float totalTime;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [Tooltip("The prefab to use for initiating the player")]
    public GameObject playerPrefab;

    //public IEnumerator StartGameCoroutine(GameObject hockey = null)
    //{
    //    AudioManager.Instance.PlayOpeningAudio(GameObject.Find("hockey").transform.position);
    //    yield return new WaitForSeconds(1f);
    //    //if (hockey)
    //    //{
    //    //    yield return new WaitForSeconds(0.5f);
    //    //    hockey.transform.position = new Vector3(768, 512, 0);
    //    //    //hockey.SetActive(true);
    //    //}
    //}

    //public void StartGame(GameObject hockey = null)
    //{
    //    if (currentOpeningCoroutine != null)
    //    {
    //        StopCoroutine(currentOpeningCoroutine);
    //    }

    //    currentOpeningCoroutine = StartCoroutine(StartGameCoroutine(hockey));
    //}
    private void Start()
    {
        timerIsRunning = false;
        timeRemaining = totalTime;

        scores[0] = 0;
        scores[1] = 0;
        crownLeft.SetActive(false);
        crownRight.SetActive(false);

        StartCoroutine(StartAudio());
    }
    public void AddScore(int goalType)
    {
        scores[goalType] += 1;
        Debug.Log(scores[0]);
        Debug.Log(scores[1]);
    }
    private void Update()
    {
        scoreLeft.text = scores[1].ToString();
        scoreRight.text = scores[0].ToString();

        //if(scores[0] == 5 || scores[1] == 5)

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
                StartCoroutine(WinGame());
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            crownLeft.SetActive(false);
            crownRight.SetActive(false);
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
    IEnumerator WinGame()
    {
        if (scores[1] > scores[0]) {
            crownLeft.SetActive(true);
        }
        else if(scores[1] < scores[0])
        {
            crownRight.SetActive(true);
        }
        else
        {
            crownLeft.SetActive(true);
            crownRight.SetActive(true);
        }
        AudioManager.Instance.PlayJubilianceAudio(GameObject.Find("hockey").transform.position);
        //yield return new WaitForSeconds(1.5f);
        //crownLeft.SetActive(false);
        //crownRight.SetActive(false);
        scores[0] = 0;
        scores[1] = 0;
        AudioManager.Instance.PlayOpeningAudio(GameObject.Find("hockey").transform.position);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator StartAudio()
    {
        AudioManager.Instance.PlayOpeningAudio(new Vector3(593,791,0));
        yield return new WaitForSeconds(1f);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

 

