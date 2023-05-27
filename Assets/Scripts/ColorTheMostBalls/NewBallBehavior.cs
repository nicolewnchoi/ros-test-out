using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] wayPoints;
    public GameObject player;
    int current = 0;
    public float speed;
    float WPradius = 1;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(wayPoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0, wayPoints.Length);
            if (current >= wayPoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[current].transform.position, Time.deltaTime * speed);
        

        /*if (Vector3.Distance(this.transform.position, wayPoints[current].transform.position) < 1)
        {
            current++;
        }
        if (current >= wayPoints.Length)
        {
            current = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[current].transform.position, Time.deltaTime * speed);
        //this.transform.Translate(0, 0, speed*Time.deltaTime);
        */
        
    }

    /*void OnTriggerEnter(Collider n)
    {
        if(n.GameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider n)
    {
        if(n.GameObject == player)
        {
            player.transform.parent = null;
        }
    }*/
}
