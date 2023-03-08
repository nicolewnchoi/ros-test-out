using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShapesPlayer
{
    public int score = 0;
    public GameObject crown;
    public Text scoreDisplay;
}

public class ShapesGameManager : MonoBehaviour
{
    public static ShapesGameManager Instance;
    [SerializeField] public ShapesPlayer[] players; //left: 0, right: 1

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
    public IEnumerator WinGame()
    {
        if(players[0].score > players[1].score)
        {
            players[0].crown.SetActive(true);
        }
        else if (players[1].score > players[0].score)
        {
            players[1].crown.SetActive(true);
        }
        else // tie
        {
            players[0].crown.SetActive(true);
            players[1].crown.SetActive(true);
        }
        AudioManager.Instance.PlayShapeWinAudio(GameObject.Find("Emitter").transform.position);
        yield return new WaitForSeconds(1.5f);
        players[0].crown.SetActive(false);
        players[0].score = 0;
        players[1].crown.SetActive(false);
        players[1].score = 0;

        //destroy all shape objects 
        GameObject[] shapes = GameObject.FindGameObjectsWithTag("Shape");
        foreach (GameObject shape in shapes)
            Destroy(shape);

        Timer.Instance.timeRemaining = GetComponent<Timer>().totalTime;
        Timer.Instance.timerIsRunning = true;
    }
}
