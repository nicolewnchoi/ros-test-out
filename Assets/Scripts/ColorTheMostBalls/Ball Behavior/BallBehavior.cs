using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;

    Vector2 wayPoint;
    //Worry aobut this later
    public float forceMagnitude;
    public new Rigidbody2D rigidbody { get; private set; }

    void Start()
    {
        InitialDestination();
        //Vector2 force = wayPoint * speed;
        Vector2 force = wayPoint * forceMagnitude;
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    void SetNewDestination()
    {
        //if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        //Actual left side

        if (transform.position.x >= 719.0f && transform.position.x <= 728.0f)
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
            MostBallsManager.Instance.AddScore(0, 1);
            MostBallsManager.Instance.AddScore(1, -1);
        }

        //else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        //Actual right side

        else if (transform.position.x >= 804.0f && transform.position.x <= 825.0f) //779.3f
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));
            MostBallsManager.Instance.AddScore(1, 1);
            MostBallsManager.Instance.AddScore(0, -1);
        }
    }

    void InitialDestination()
    {
        if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));
        }
        else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Line")
        {
            Debug.Log("Collision with Player and Circle detected");
            SetNewDestination();
            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EnableBox(1.0F));
        }
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    void Update()
    {
        //This code doesn't update the position very well
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        //I only want the individual ball to just change movement direction
        if (Vector2.Distance(this.transform.position, wayPoint) < range)
        {
            //Debug.Log("Vector2.Distance: " + Vector2.Distance(transform.position, wayPoint));
            InitialDestination();
        }
    }
}
