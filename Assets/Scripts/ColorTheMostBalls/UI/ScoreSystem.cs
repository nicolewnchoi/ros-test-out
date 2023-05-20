using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public MostBallsManager manage;

    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.FindGameObjectWithTag("Circle").GetComponent<MostBallsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            UpdatePlayerScore(1);
        }
    }

    private void UpdatePlayerScore(int points)
    {
        if (transform.position.x < 706)
        {
            manage.AddScore(0, points);
            //MostBallsManager.Instance.AddScore(0, points);
        }
        else
        {
            manage.AddScore(1, points);
            //MostBallsManager.Instance.AddScore(1, points);
        }
    }
}
