using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosPos = RosMessageTypes.ApInterfaces.PosMsg;
using RosButton = RosMessageTypes.ApInterfaces.ButtonMsg;

public class testpublish : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "pos_raw";

    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<RosPos>(topicName);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            // Finally send the message to server_endpoint.py running in ROS
            
            RosPos publish = new RosPos(1, 0,new double[]{10}, new double[] { 10 }, new sbyte[] { 1 }, new string[] { "1"},new double[] { 10});
            ros.Publish(topicName, publish);

            timeElapsed = 0;
        }
    }
}
