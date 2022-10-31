using rosAirHockyinData = RosMessageTypes.ApInterfaces.AddThreeIntsRequest;
using rosAirHockyreturnData = RosMessageTypes.ApInterfaces.AddThreeIntsResponse;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class servertest : MonoBehaviour
{
    ROSConnection ros;

    public string serviceName = "unity_srv";


    float awaitingResponseUntilTimestamp = -1;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterRosService<rosAirHockyinData, rosAirHockyreturnData>(serviceName);
    }

    private void FixedUpdate()
    {
      

        rosAirHockyinData testdata = new rosAirHockyinData();

        // Send message to ROS and return the response
        ros.SendServiceMessage<rosAirHockyreturnData>(serviceName, testdata, Callback_Destination);
        awaitingResponseUntilTimestamp = Time.time + 1.0f; // don't send again for 1 second, or until we receive a response
        
    }
    
    void Callback_Destination(rosAirHockyreturnData response)
    {
        Debug.Log("succeed");
    }
}