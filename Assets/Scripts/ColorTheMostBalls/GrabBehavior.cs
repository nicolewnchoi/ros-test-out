using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour
{
    public float speed = 50f;
    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    // Start is called before the first frame update
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Circle");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            //grabs object
            if (grabbedObject == null)
            {
                hitInfo.collider.gameObject.transform.parent = grabPoint;
                hitInfo.collider.gameObject.transform.position = grabPoint.position;
                hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

                /*grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);*/
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hitInfo.collider.gameObject.transform.parent = null;
                hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().velocity = grabPoint.forward * speed;
                //grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                //grabbedObject.transform.SetParent(null);
                //grabbedObject = null;
            }
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
