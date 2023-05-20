using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BallBehavior : MonoBehaviour
{
    //make the ball's mass heavier as soon as the player grabs the ball

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
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(xMin, xMax), Random.Range(62.7f, 800.0f));
        //wayPoint = new Vector2(Random.Range(59.1f, 1474.4f), Random.Range(62.7f, 800.0f));
        //59.1f (first half start x distance)
        //705.9f (first half end x distance)
        //822.9f (first half start x distance)
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
            ShapesGameManager.Instance.AddScore(0, points);
            //MostBallsManager.Instance.AddScore(0, points);
        }
        else
        {
            ShapesGameManager.Instance.AddScore(1, points);
            //MostBallsManager.Instance.AddScore(1, points);
        }
    }

}
