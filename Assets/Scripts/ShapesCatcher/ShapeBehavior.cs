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
}
