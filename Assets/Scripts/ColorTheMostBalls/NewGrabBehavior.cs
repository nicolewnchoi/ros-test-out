/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrabBehavior : MonoBehaviour
{
    public Transform holdSpot;
    private GameObject grabbedObject;
    private float pickUpMask;
    public Vector3 Direction { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (grabbedObject) //if grabbedObject is null
        {
            grabbedObject.transform.position = transform.position;
            grabbedObject.transform.parent = null;
            if (grabbedObject.GetComponent<Rigidbody2D>())
            {
                grabbedObject.GetComponent<Rigidbody2D>().simulated = true;
            }
            grabbedObject = null;
        }
        else
        {
            RaycastHit2D pickUp = Physics2D.Raycast(holdSpot.position, .4f, pickUpMask);

            if (grabbedObject)
            {
                grabbedObject = pickUp.GameObject;
                grabbedObject.transform.position = holdSpot.position;
                grabbedObject.transform.parent = transform;
                if (grabbedObject.GetComponent<Rigidbody2D>())
                {
                    grabbedObject.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(grabbedObject)
            {
                StartCoroutine(ThrowItem(grabbedObject));
                grabbedObject = null;
            }
        }
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 2;
        item.transform.parent = null;
        for (int i = 0; i < 25; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * .04f);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>())
        {
            item.GetComponent<Rigidbody2D>().simulated = true;
        }
    }
}*/
