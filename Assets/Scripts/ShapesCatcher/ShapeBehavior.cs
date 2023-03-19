using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

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
                StartCoroutine(PlayCatchSpecialAudio());
                UpdatePlayerScore(5);

                return;
            }
            int boundaryShapeType = (int)collision.gameObject.GetComponent<ShapeClass>().shape;
            int shapeType = (int)GetComponent<ShapeClass>().shape;
            if (boundaryShapeType == shapeType)
            {
                StartCoroutine(PlayCatchAudio());
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
    IEnumerator PlayCatchAudio()
    {
        AudioManager.Instance.PlayCatchSpecialShapeAudio(transform.position);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator PlayCatchSpecialAudio()
    {
        AudioManager.Instance.PlayCatchSpecialShapeAudio(transform.position);
        yield return new WaitForSeconds(1f);
    }
}
