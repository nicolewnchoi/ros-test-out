using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySetup : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(768, 1024, true, 60);
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate(768, 1024, 60);
        }
    }
}
