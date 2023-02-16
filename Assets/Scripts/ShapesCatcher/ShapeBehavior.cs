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
            if (collision.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                if (transform.position.x < 768) // left of center
                {
                    ShapesGameManager.Instance.AddScore(0, 1);
                }
                else
                {
                    ShapesGameManager.Instance.AddScore(1, 1);
                }
                Destroy(gameObject);
            }
        }
    }
}
