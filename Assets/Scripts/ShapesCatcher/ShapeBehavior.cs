using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehavior : MonoBehaviour
{
    public float dieTime = 15f;
    public Vector2 random;
    public float forceMagnitude = 5000;

    private void Start()
    {
        if (gameObject.name == "Heart_Shape(Clone)")
        {
            dieTime = 5f;
        }
        Vector2 force = random * forceMagnitude;
        GetComponent<Rigidbody2D>().AddForce(force);
        StartCoroutine(KillShape());
    }
    IEnumerator KillShape()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "Heart_Shape(Clone)")
            {
                UpdatePlayerScore(5);
            }
            string boundaryShapeType = collision.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.name.Split('_')[0];
            string shapeType = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            if (boundaryShapeType == shapeType)
            {
                UpdatePlayerScore(1);
            }
        }
    }
    private void UpdatePlayerScore(int points)
    {
        if (transform.position.x < 768) // left of center
        {
            ShapesGameManager.Instance.AddScore(0, points);
        }
        else
        {
            ShapesGameManager.Instance.AddScore(1, points);
        }
        Destroy(gameObject);
    }
}
