using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    private void Start()
    {
        //UnityRosSetup();
        //CVSetup();
        StartCoroutine(Wait());
    }

    private void CVSetup()
    {
        string strCmdText;
        strCmdText = "/C c:/opt/ros/foxy/x64/setup.bat" +
            "&cd C:/ros2newarch/ros2/ros2_emulation/src" +
            "&call install/setup.bat" + 
            "&ros2 launch ap_interfaces airplay_launch.py";
        System.Diagnostics.Process.Start("cmd.exe", strCmdText);
        //System.Diagnostics.Process process = new System.Diagnostics.Process();
        //process.StartInfo.FileName = "C:/ProgramData/Microsoft/Windows/Start Menu/Programs/Visual Studio 2019/Visual Studio Tools/VC/x64 Native Tools Command Prompt for VS 2019.exe";
        //process.StartInfo.Arguments = strCmdText;
        //process.StartInfo.UseShellExecute = true;
        //process.StartInfo.Verb = "runas";
        //process.Start();
    }

    private void UnityRosSetup()
    {
        string unity_ros_cmd;
        unity_ros_cmd = "/C c:/opt/ros/foxy/x64/setup.bat" +
            "&cd C:/ros2newarch/ros2/ros2_emulation/src" +
            //"&colcon build--merge - install" +
            "&call install/setup.bat" +
            "&ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ROS_IP:=169.254.0.1 -p ROS_TCP_PORT:=10000";
        System.Diagnostics.Process.Start("cmd.exe", unity_ros_cmd);
        //System.Diagnostics.Process process = new System.Diagnostics.Process();
        //process.StartInfo.FileName = "C:/ProgramData/Microsoft/Windows/Start Menu/Programs/Visual Studio 2019/Visual Studio Tools/VC/x64 Native Tools Command Prompt for VS 2019.exe";
        //process.StartInfo.Arguments = unity_ros_cmd;

        //process.Start();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        UnityRosSetup();
        yield return new WaitForSeconds(10f);
        CVSetup();
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("AirHockey");
    }
}
