using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Robotics.UrdfImporter.Link;

public class hockeyctr : MonoBehaviour
{
    
    public float kickFactor;
    public Vector3 startpoint;
    public bool debugmode;
    // Start is called before the first frame update
    void Start()
    {
        gameMgr.Inst.updateevent.AddListener(updatefriction);
    }

    // Update is called once per frame
    void Update()
    {
        if (debugmode)
        {
            
            if (Input.GetKeyDown(KeyCode.D))
            {    
                Vector2 force = Vector2.right * 10000;
                force *= 1 * kickFactor * gameMgr.Inst.currentData.ballSpeed;
                GetComponent<Rigidbody2D>().AddForce(force);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Vector2 force = Vector2.left * 10000;
                force *= 1 * kickFactor * gameMgr.Inst.currentData.ballSpeed;
                GetComponent<Rigidbody2D>().AddForce(force);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Vector2 force = Vector2.down * 10000;
                force *= 1 * kickFactor * gameMgr.Inst.currentData.ballSpeed;
                GetComponent<Rigidbody2D>().AddForce(force);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Vector2 force = Vector2.up * 10000;
                force *= 1 * kickFactor * gameMgr.Inst.currentData.ballSpeed;
                GetComponent<Rigidbody2D>().AddForce(force);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector2 force = collision.gameObject.transform.position - transform.position;
            force *=  -1 * kickFactor * gameMgr.Inst.currentData.ballSpeed;
            GetComponent<Rigidbody2D>().AddForce(force);
            AudioManager.Instance.PlayKickAudio(collision.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "leftgoal")
        {

        }
        else
        {

        }
        transform.position = startpoint;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void updatefriction()
    {
        GetComponent<Collider2D>().sharedMaterial.friction = gameMgr.Inst.currentData.friction;
    }
}
