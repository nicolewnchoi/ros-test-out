using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField]
    private Transform grabPoint;
    private Transform player;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    private Rigidbody2D rb;
    public float forceMulti = 10f;
    public Vector3 Direction { get; set; }


    // Start is called before the first frame update
    private void Start()
    {
       // player = GameObject.Find("BallPlayer").transform;
        //player = GameObject.Find("Circle").transform;
        layerIndex = LayerMask.NameToLayer("Circle");
    }

    //rb.velocity = new Vector2(player.transform.localScale.x, 2) * (forceMulti / 10);

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {

            //grabs object
            if (grabbedObject == null)
            {
                hitInfo.collider.gameObject.transform.parent = grabPoint;
                hitInfo.collider.gameObject.transform.position = grabPoint.position;
                //hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ThrowItem(hitInfo);
                //forceMulti += 30 * Time.deltaTime;
                //hitInfo.collider.gameObject.AddForce(grabPoint.forward * 300);

                //Recently working code:
                Vector3 startPoint = hitInfo.collider.gameObject.transform.position;
                Vector3 endPoint = hitInfo.collider.gameObject.transform.position + Direction * 2;

                //Recently working code:
                hitInfo.collider.gameObject.transform.parent = null;
                //hitInfo.collider.gameObject.transform.position = Vector3.zero;
                //hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

                //Recently working code
                for (int i = 0; i < 25; i++)
                {
                    hitInfo.collider.gameObject.transform.position = Vector3.Lerp(startPoint, endPoint, i * .04f);
                    hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x, 1) * forceMulti;
                    //yield return null;
                }

                if (hitInfo.collider.gameObject.GetComponent<Rigidbody2D>())
                {
                    hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                    //hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x, 1) * forceMulti;

                }

                if (transform.position.x >= 59.1f && transform.position.x <= 705.9f)
                {
                    MostBallsManager.Instance.AddScore(0, 1);
                    MostBallsManager.Instance.AddScore(1, -1);
                }

                else if (transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
                {
                    MostBallsManager.Instance.AddScore(1, 1);
                    MostBallsManager.Instance.AddScore(0, -1);
                }

                //hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * forceMulti;

                //Recently working code:
                //hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x, 1) * forceMulti;

                Debug.Log("Circle fired!");

            }
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
