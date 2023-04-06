using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private void Awake()
    {
        UnityRosSetup();
        CVSetup();
    }

    private void CVSetup()
    {
        string strCmdText;
        strCmdText = "/C c:/opt/ros/foxy/x64/setup.bat";
        strCmdText += "&cd C:/Users/sonia/Documents/ros2_emulation/src";
        //strCmdText += "&colcon build --merge-install --packages-select ap_interfaces";
        strCmdText += "&call install/setup.bat&ros2 run ap_interfaces player_detection";
        System.Diagnostics.Process.Start("cmd.exe", strCmdText);
    }

    private void UnityRosSetup()
    {
        string unity_ros_cmd;
        unity_ros_cmd = "/C c:/opt/ros/foxy/x64/setup.bat" +
            "&cd C:/Users/sonia/Documents/ros2_emulation/src" +
            //"&colcon build--merge - install" +
            "&call install/setup.bat" +
            "&ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ROS_IP:=172.18.208.1 -p ROS_TCP_PORT:=10000";
        System.Diagnostics.Process.Start("cmd.exe", unity_ros_cmd);
    }
}
