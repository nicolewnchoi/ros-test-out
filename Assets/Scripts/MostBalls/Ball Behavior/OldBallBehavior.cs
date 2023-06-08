using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class OldBallBehavior : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float xMin;
    [SerializeField]
    float xMax;

    Vector2 wayPoint;

    //public Vector2 random;
    //public float speed = 10.0f;
    //public float forceMagnitude = 5000;
    //private Rigidbody2D rb;
    //public Vector2 movement;

    void Start()
    {
        SetNewDestination();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, wayPoint) < range)
        {
            Debug.Log("Vector2.Distance: " + Vector2.Distance(transform.position, wayPoint));
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        //wayPoint = new Vector2(Random.Range(xMin, xMax), Random.Range(62.7f, 800.0f));

        if (transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));
        }
        else if (transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
        }

        //wayPoint = new Vector2(Random.Range(59.1f, 1474.4f), Random.Range(62.7f, 800.0f));
        //59.1f (first half start x distance)
        //705.9f (first half end x distance)
        //822.9f (first half start x distance)
    }

    //Any easier way to store the circles on both sides?
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //Currently working code 
        if (collision.gameObject.tag == "leftgoal")
        {
            //shrunk the leftgoal size
            //UpdatePlayerScore(1);
            MostBallsManager.Instance.AddScore(1, 1);
            MostBallsManager.Instance.AddScore(0, -1);
            Debug.Log("updateScoreLeft");

            //Debug.Log("leftgoal");
        }
        if (collision.gameObject.tag == "rightgoal")
        {
            //shrunk the rightgoal size
            //UpdatePlayerScore(1);
            MostBallsManager.Instance.AddScore(0, 1);
            MostBallsManager.Instance.AddScore(1, -1);
            Debug.Log("updateScoreRight");
            //Debug.Log("rightgoal");
        }

        //Currently working code

        /*if (collision.gameObject.tag == "leftgoal")
        {
            if (collision.gameObject.tag == "Circle")
            {
                UpdatePlayerScore(1);
            }
        }

        if (collision.gameObject.tag == "rightgoal")
        {
            if (collision.gameObject.tag == "Circle")
            {
                UpdatePlayerScore(1);
            }
        }*/

        /*if (collision.gameObject.tag == "Circle")
        {
            if (gameObject.name == "LeftTeam")
            {
                UpdatePlayerScore(1);
            }
            else if (gameObject.name == "RightTeam")
            {
                UpdatePlayerScore(1);
            }
            /*if (gameObject.name == "LeftTeam" || gameObject.name == "RightTeam")
            {
                UpdatePlayerScore(1);
            }
        }
    }*/

    /*private void UpdatePlayerScore(int points)
    {
        if (transform.position.x < 706)
        {
            //MostBallsManager.Instance.AddScore(1, points);
            MostBallsManager.Instance.AddScore(1, 1);
            Debug.Log("updateScoreLeft");
        }
        else
        {
            //MostBallsManager.Instance.AddScore(0, points);
            MostBallsManager.Instance.AddScore(0, 1);
            Debug.Log("updateScoreRight");
        }
    }*/

}
