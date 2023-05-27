using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WallMostBalls : MonoBehaviour
{
    private Coroutine wallCoroutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            if (wallCoroutine != null)
            {
                StopCoroutine(wallCoroutine);
            }

            //wallCoroutine = StartCoroutine(Wall(collision.gameObject, collision.transform));
            wallCoroutine = StartCoroutine(Wall(collision.gameObject));
        }

        //I have no idea if this makes any difference
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    //private IEnumerator Wall(GameObject hockey, Transform current)
    private IEnumerator Wall(GameObject hockey)
    {
        if (hockey.CompareTag("Circle"))
        {
            //AudioManager.Instance.PlayBoundaryAudio(current.position);
            yield return new WaitForSeconds(1f);
        }
    }
}
