using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehavior : MonoBehaviour
{
    //public float movementSpeed;
    public float dieTime = 15f;
    public Vector2 random;


    private void Start()
    {
        //random = RandomSpawner(3*Mathf.PI/2, Mathf.PI);
        Debug.Log(random);
        Vector2 force = random * 5000;
        GetComponent<Rigidbody2D>().AddForce(force);
        StartCoroutine(KillShape());
    }
    IEnumerator KillShape()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }
}
