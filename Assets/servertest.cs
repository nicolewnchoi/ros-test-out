using rosAirHockyinData = RosMessageTypes.ApInterfaces.AddThreeIntsRequest;
using rosAirHockyreturnData = RosMessageTypes.ApInterfaces.AddThreeIntsResponse;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using UnityEditor;

public class servertest : MonoBehaviour
{
    ROSConnection ros;

    public string serviceName = "unity_srv";
    public float ballradius;
    public float ballspeed;
    public float goalsize;
    public float friction;
    public float buttonspeed;

    float awaitingResponseUntilTimestamp = -1;

    private void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterRosService<rosAirHockyinData, rosAirHockyreturnData>(serviceName);
    }
    private void FixedUpdate()
    {
      

        rosAirHockyinData testdata = new rosAirHockyinData();
        testdata.ballradius = 1;
        testdata.ballspeed = 1;
        testdata.goalsize = 1;
        testdata.friction = 0.4f;
        testdata.buttonspeed = 1;
        // Send message to ROS and return the response
        ros.SendServiceMessage<rosAirHockyreturnData>(serviceName, testdata, Callback_Destination);
        //awaitingResponseUntilTimestamp = Time.time + 1.0f; // don't send again for 1 second, or until we receive a response
        
    }
    
    void Callback_Destination(rosAirHockyreturnData response)
    {
        Debug.Log("succeed");
    }

    //private void OnGUI()
    //{
    //    //ballradius = EditorGUILayout.Slider("Slider", ballradius, -3, 3);
    //    if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
    //    {
    //        print("You clicked the button!");
    //    }
    //}
}