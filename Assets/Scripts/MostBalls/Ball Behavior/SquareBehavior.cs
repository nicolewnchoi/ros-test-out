using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;

    Vector2 wayPoint;
    public float forceMagnitude;
    //public new Rigidbody2D rigidbody { get; private set; }
    private Rigidbody2D rigidbody;
    //public GameObject gb;
    //public GameObject[] shapesArray;
    //int shapeType;
    //Vector3 shapePosition = GameObject.FindGameObjectsWithTag("Shape").transform.position;

    void Start()
    {
        if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        {
            MostBallsManager.Instance.AddScore(1, 1);
        }
        else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            MostBallsManager.Instance.AddScore(0, 1);
        }

        InitialDestination();

        //Worry aobut this later, I have no idea if this improves the frequent stickings like a glue
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(5f, 5f);

        Vector2 force = wayPoint * forceMagnitude;
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /*void Update()
    {
        Vector3 vDist = wayPoint;
        gb.FindGameObjectsWithTag("Shape").Count(gb => Vector3.Distance(vDist, gb.transform.position) < 981);
    }*/

    void SetNewDestination()
    {
        //if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        //Actual left side, when the right ball crosses to the left side

        //if (transform.position.x >= 719.0f && transform.position.x <= 728.0f) //The one that actually worked
        if (transform.position.x >= 717.0f && transform.position.x <= 725.0f)
            //if (transform.position.x >= 759.0f && transform.position.x <= 770.0f)
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
            MostBallsManager.Instance.AddScore(0, 1);
            MostBallsManager.Instance.AddScore(1, -1);
            MostBallsAudio.Instance.PlayBoundaryAudio(GameObject.Find("field").transform.position);
        }

        //else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        //Actual right side, when the left ball crosses to the right side

        //else if (transform.position.x >= 804.0f && transform.position.x <= 825.0f) //The one that actually worked
        else if (transform.position.x >= 810.0f && transform.position.x <= 818.0f)        
        //else if (transform.position.x >= 776.0f && transform.position.x <= 780.0f)
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));
            MostBallsManager.Instance.AddScore(1, 1);
            MostBallsManager.Instance.AddScore(0, -1);
            MostBallsAudio.Instance.PlayBoundaryAudio(transform.position);
        }
    }

    void InitialDestination()
    {
        if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));
            //MostBallsManager.Instance.AddScore(0, 1);
        }
        else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
            //MostBallsManager.Instance.AddScore(1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Line")
        {
            Debug.Log("Collision with Player and Circle detected");
            SetNewDestination();

            //GameObject shape = shapesArray[shapeType];
            /*foreach (GameObject shape in shapesArray)
            {
                if (shape == GameObject.Find("Circle"))
                {
                    GetComponent<CircleCollider2D>().enabled = false;
                }
                if (shape == GameObject.Find("Square"))
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }*/

            //GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(EnableBox(1.0F));
        }
    }

    IEnumerator Scoring(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        /*foreach (GameObject shape in shapesArray)
        {
            if (shape == GameObject.Find("Circle"))
            {
                GetComponent<CircleCollider2D>().enabled = false;
            }
            if (shape == GameObject.Find("Square"))
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }*/


        GetComponent<BoxCollider2D>().enabled = true;
        //GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        /*foreach (GameObject shape in shapesArray)
        {
            if (shape == GameObject.Find("Circle"))
            {
                GetComponent<CircleCollider2D>().enabled = false;
            }
            if (shape == GameObject.Find("Square"))
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }*/


        GetComponent<BoxCollider2D>().enabled = true;
        //GetComponent<CircleCollider2D>().enabled = true;
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

