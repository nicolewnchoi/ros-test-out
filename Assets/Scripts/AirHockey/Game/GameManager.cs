using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public int[] scores = new int[2];
    private Coroutine currentOpeningCoroutine;

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

    public IEnumerator StartGameCoroutine(GameObject hockey = null)
    {
        AudioManager.Instance.PlayOpeningAudio(Vector3.zero);
        if (hockey)
        {
            yield return new WaitForSeconds(0.5f);
            hockey.transform.position = Vector3.zero;
            hockey.SetActive(true);
        }
    }

    public void StartGame(GameObject hockey = null)
    {
        if (currentOpeningCoroutine != null)
        {
            StopCoroutine(currentOpeningCoroutine);
        }

        currentOpeningCoroutine = StartCoroutine(StartGameCoroutine(hockey));
    }
}

 

