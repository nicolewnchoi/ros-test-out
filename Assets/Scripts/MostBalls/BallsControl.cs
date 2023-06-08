using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsControl : MonoBehaviour
{
    public GameObject balls;
    private int ball_count = 11;
    public float speed = 100.0f;

    void Move()
    {
        //Random movement of the circles
        for (int i = 0; i < ball_count; i++)
        {
            Vector3 pos = GetRandomPosition();
            transform.position += pos * Time.deltaTime * speed;
        }

    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(64.7f, 702.6f), Random.Range(66.2f, 958.6f), 0);
        Vector3 direction = (randomPosition - transform.position).normalized;
        //Vector3 direction = Vector3.Distance(randomPosition, transform.position);
        return randomPosition;
    }
}
