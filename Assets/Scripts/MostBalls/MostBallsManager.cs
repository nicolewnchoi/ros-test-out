using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BallsPlayer
{
    public int score = 0;
    public GameObject crown;
    public Text scoreDisplay;
}

public class MostBallsManager : MonoBehaviour
{
    public static MostBallsManager Instance;
    [SerializeField] public BallsPlayer[] players; //left: 0, right: 1

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

    private void Update()
    {
        players[0].scoreDisplay.text = players[0].score.ToString();
        players[1].scoreDisplay.text = players[1].score.ToString();
    }

    public void AddScore(int side, int score)
    {
        players[side].score += score;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "leftgoal")
        {
            Debug.Log("Score from left side");
            AddScore(0, 1);
            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(Scoring(1.0F));
        }

        if (collider.tag == "rightgoal")
        {
            Debug.Log("Score from right side");
            AddScore(1, 1);
            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(Scoring(1.0F));
        }
    }

    IEnumerator Scoring(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public IEnumerator WinGame()
    {
        if (players[0].score < players[1].score)
        {
            players[0].crown.SetActive(true);
        }
        else
        {
            players[1].crown.SetActive(true);
        }
        
        //The 
        //MostBallsAudio.Instance.PlayShapeWinAudio(GameObject.Find("field").transform.position);

        yield return new WaitForSeconds(5.0f);
        players[0].crown.SetActive(false);
        players[0].score = 0;
        players[1].crown.SetActive(false);
        players[1].score = 0;

        GameObject[] shapes = GameObject.FindGameObjectsWithTag("Shape");
        foreach (GameObject shape in shapes)
            Destroy(shape);

        //TimerMostBalls.Instance.timeRemaining = GetComponent<TimerMostBalls>().totalTime;
        //TimerMostBalls.Instance.timerIsRunning = true;
    }
}

