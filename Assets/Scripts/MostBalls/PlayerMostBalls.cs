using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMostBalls : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector3 startPosition;
    public GameObject player;
    public Transform circleTransform;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        if (startPosition.x < 768) // left of center
        {
            LeftKeyboardMovement();
        }
        else
        {
            RightKeyboardMovement();
        }
    }

    //Keyboard control version
    //Maybe can do better than this
    private void OnCollisionEnter2D(Collision2D col) //ball expands during contact
    {
        if (col.gameObject.CompareTag("Shape"))
        {
            Debug.Log("Player's circle increased");
            circleTransform.localScale = new Vector3(circleTransform.localScale.x + 30.0f, circleTransform.localScale.y + 30.0f, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D col) //ball shrinks when no longer in contact
    {
        if (col.gameObject.CompareTag("Shape"))
        {
            Debug.Log("Player's circle normal");
            circleTransform.localScale = new Vector3(circleTransform.localScale.x - 30.0f, circleTransform.localScale.y - 30.0f, 0);
        }
    }

    private void LeftKeyboardMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
    private void RightKeyboardMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}

