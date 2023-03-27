using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public string[] scenes;

    public static Instructions Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        for (int i = 0; i < scenes.Length; ++i)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (SceneManager.GetActiveScene().name == scenes[i] && SceneManager.GetActiveScene().name != scenes[scenes.Length - 1])
                {
                    SceneManager.LoadScene(scenes[i + 1]);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (SceneManager.GetActiveScene().name == scenes[i] && SceneManager.GetActiveScene().name != scenes[0])
                {
                    SceneManager.LoadScene(scenes[i - 1]);
                }
            }
        }
    }
}
