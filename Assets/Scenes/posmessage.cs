using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosPos = RosMessageTypes.ApInterfaces.PosMsg;
using RosButton = RosMessageTypes.ApInterfaces.ButtonMsg;
using rosAirHockyinData = RosMessageTypes.ApInterfaces.AddThreeIntsRequest;
using rosAirHockyreturnData = RosMessageTypes.ApInterfaces.AddThreeIntsResponse;
using UnityEngine.UI;
using System;

using RosMessageTypes.UnityRoboticsDemo;

public class posmessage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectbase;
    public List<GameObject> objects;
    public List<float> x;
    public List<float> y;
    public List<float> r;

    //for debug
    public Text text;
    public Text text2;
    public Text text3;

    //for store weather kick button ispressed
    bool[] kickbutton;

    //create an empty message for moving the player detection from a callback to an update frame
    RosPos rosPosMsg;
    bool newMsgAvailable;
    double msgReceivedTime;
    int msgReceivedId;

    int counter;

    //unity service name
    string m_ServiceName = "unity_srv";

    

    private void Awake()
    {
        
        
    }

    void Start()
    {
        counter = 0;
        newMsgAvailable = false;
        msgReceivedTime = 0;
        msgReceivedId = 0;
        //objects1.SetActive(true); //test for DrawCircle
        //objects1.transform.position = new Vector3(3f, 4f, 0f);
        //objects2.transform.position = new Vector3(0f, 4f, 0f);
        //DrawCircle(objects1, 200, 1.5f, 0.2f);
        //DrawCircle(objects2, 200, 0.7f, 0.2f);
        //set resolution of our screen
        Screen.SetResolution(768, 1024, true, 60);
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate(768, 1024, 60);
        }
        kickbutton = new bool[] { };
        ROSConnection.GetOrCreateInstance().ImplementService<rosAirHockyinData, rosAirHockyreturnData>(m_ServiceName, currentStatus);
        ROSConnection.GetOrCreateInstance().Subscribe<RosPos>("pos_raw", posChange);
        ROSConnection.GetOrCreateInstance().Subscribe<RosButton>("kick_size", kickChange);

        //Experiment with publish everytime we receive a message to see where latency is
        ROSConnection.GetOrCreateInstance().RegisterPublisher<PosRotMsg>("pos_heard");

    }

    // Update is called once per frame
    void Update()
    {
        if (newMsgAvailable)
        {
            //note time we begin to render
            double beginRenderTime = (System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds;

            float projector_height = 1024;
            float projector_width = 768;
            float cv_width = 720f;
            float cv_height = 480f;

            float perspective_x = 2 * projector_width / cv_width;
            float perspective_y = projector_height / cv_height;  //same

            int player_num = rosPosMsg.total;


            while (objects.Count < player_num)
            {
                objects.Add(Instantiate(objectbase));
                x.Add(0);
                y.Add(0);
                r.Add(0);
                Debug.Log("Creating object");
            }

            while (objects.Count > player_num)
            {
                Destroy(objects[objects.Count - 1]);
                objects.Remove(objects[objects.Count - 1]);
                x.Remove(x[x.Count - 1]);
                y.Remove(y[y.Count - 1]);
                r.Remove(r[r.Count - 1]);
                Debug.Log("Destroying object");
            }

            for (int i = 0; i < player_num; i++)
            {
                x[i] = (float)rosPosMsg.x[i] * perspective_x;
                y[i] = (float)rosPosMsg.y[i] * perspective_y;
                r[i] = (float)rosPosMsg.size[i] * perspective_x;

                var pos1 = new Vector3(x[i], y[i], 0);
                objects[i].transform.position = pos1;

                //if is kicked set the size to a abosolute
                if (kickbutton.Length == player_num && kickbutton[i])
                {
                    r[i] = 500; //need change later when we get gamemanager
                }

                var radius = gameMgr.Inst.currentData.ballRadius;

                DrawCircle(objects[i], 200, r[i] * radius, 10f);
                //update the collider
                objects[i].GetComponent<CircleCollider2D>().radius = r[i] * radius;
                //Debug.Log(objects[i].GetComponent<CircleCollider2D>().radius);
            }
            newMsgAvailable = false;

            double endRenderTime = (System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds;

            Debug.Assert((int)rosPosMsg.id == msgReceivedId);
            double msgSentTime = (double)rosPosMsg.ms;
            Debug.LogFormat("msgid:{0} sent at {1:00}, received with {2:00}, begin render at {3:00} and finished render at {4:00}",
                msgReceivedId, msgSentTime, msgReceivedTime - msgSentTime, beginRenderTime - msgSentTime, endRenderTime - msgSentTime);

            //Publish results in new ros message for monitoring
            PosRotMsg cubePos = new PosRotMsg(
                    msgReceivedId,
                    (float)msgSentTime,
                    (float)(msgReceivedTime - msgSentTime),
                    (float)(beginRenderTime - msgSentTime),
                    (float)(endRenderTime - msgSentTime),
                    0,
                    0
                );
            ROSConnection.GetOrCreateInstance().Publish("pos_heard", cubePos);

        }

    }

    void posChange(RosPos rosPos)
    {
        //get the time as soon as we enter the callback so we can compare to the time the 
        // message was sent
        double currms = (System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds;
        msgReceivedTime = currms;
        newMsgAvailable = true;
        rosPosMsg = rosPos;
        msgReceivedId = (int)rosPos.id;

        //var x = (float)rosPos.x[0];
        //var y = (float)rosPos.y[0];
        //var pos = Camera.main.ScreenToWorldPoint(new Vector3(x, y,Camera.main.nearClipPlane));//convert to normal coordinate
        // pos.z = 0;
        //Debug.Log(rosPos.total + " and " + rosPos.x[0] + " and " + rosPos.y[0] + "and" + rosPos.size);
        // Debug.Log(rosPos.total);
        // Debug.Log(rosPos.size[0] + "and" + rosPos.size[1] +"and"+ rosPos.size[2]);
    }

    void DrawCircle(GameObject object_temp, int steps, float radius, float width)
    {
        object_temp.GetComponent<LineRenderer>().positionCount = (steps + 1);
        object_temp.GetComponent<LineRenderer>().startWidth = width;

        for (int i = 0; i < steps + 1; i++)
        {
            float x = radius * Mathf.Cos((360f / steps * i) * Mathf.Deg2Rad) + object_temp.transform.position.x;
            float y = radius * Mathf.Sin((360f / steps * i) * Mathf.Deg2Rad) + object_temp.transform.position.y;
            object_temp.GetComponent<LineRenderer>().SetPosition(i, new Vector3(x, y, object_temp.transform.position.z));
        }

    }

    void kickChange(RosButton kicksize)
    {
        kickbutton = kicksize.kick;
    }

    rosAirHockyreturnData currentStatus(rosAirHockyinData inData)
    {
        Debug.Log("Message Received!");
        return gameMgr.Inst.tryUpdate(inData);
    }

}