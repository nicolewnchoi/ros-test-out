using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class cameraAdjust : MonoBehaviour
{
    public List<Camera> cameralists;
    int height;
    int width;
    public float wid = 1536f;
    public float hei = 1024f;

    
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        height = Screen.height;
        width = Screen.width;

        //position
        var position = cameralists[0].transform.position;
        position.x = wid / 2 - 1.0f * (cameralists[0].orthographicSize) * width / height;
        position.y = 1f * hei / 2;
        cameralists[0].transform.position = position;

        position = cameralists[1].transform.position;
        position.x = wid / 2 + 1.0f * (cameralists[1].orthographicSize) * width / height;
        position.y = 1f * hei / 2;
        cameralists[1].transform.position = position;

    }


}
