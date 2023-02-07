using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WallControl : MonoBehaviour
{
    // Start is called before the first frame update
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Hockey"))
    //    {
    //        AudioManager.Instance.PlayBoundaryAudio(other.transform.position);

    //    }
    //}
    private Coroutine wallCoroutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hockey"))
        {
            if (wallCoroutine != null)
            {
                StopCoroutine(wallCoroutine);
            }

            wallCoroutine = StartCoroutine(Wall(collision.gameObject, collision.transform));
        }
    }

    private IEnumerator Wall(GameObject hockey, Transform current)
    {
        if (hockey.CompareTag("Hockey"))
        {
            AudioManager.Instance.PlayBoundaryAudio(current.position);
            yield return new WaitForSeconds(1f);
        }
    }
}