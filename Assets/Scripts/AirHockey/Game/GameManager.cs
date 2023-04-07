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

        if(scores[0] == 5 || scores[1] == 5)
        {
            StartCoroutine(WinGame());
        }
    }
    IEnumerator WinGame()
    {
        if (scores[1] == 5) {
            crownLeft.SetActive(true);
        }
        else
        {
            crownRight.SetActive(true);
        }
        AudioManager.Instance.PlayJubilianceAudio(GameObject.Find("hockey").transform.position);
        yield return new WaitForSeconds(1.5f);
        crownLeft.SetActive(false);
        crownRight.SetActive(false);
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
}

 

