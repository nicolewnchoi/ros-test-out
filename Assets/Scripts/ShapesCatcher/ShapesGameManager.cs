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
}
