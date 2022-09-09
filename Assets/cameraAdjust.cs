using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAdjust : MonoBehaviour
{
    public List<Camera> cameralists;
    float height;
    float width;
    //float wid = 12.8f;
    //float hei = 10.24f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Screen Height : " + Screen.height);
        Debug.Log("Screen width : " + Screen.width);
        height = (float)Screen.height;
        width = (float)Screen.width;

        //position
        var position = cameralists[0].transform.position;
        position.x = width / 2f;
        position.y = 1f * height / 2;
        cameralists[0].orthographicSize = height / 2;
        cameralists[0].transform.position = position;

        position = cameralists[1].transform.position;
        position.x = width * 3f / 2f;
        position.y = 1f * height / 2;
        cameralists[1].orthographicSize = height / 2;
        cameralists[1].transform.position = position;

        //var position = cameralists[0].transform.position;
        //position.x = wid / 2 - 1.0f * (cameralists[0].orthographicSize) * width / height;
        //position.y = 1f * hei / 2;
        //cameralists[0].transform.position = position;

        //position = cameralists[1].transform.position;
        //position.x = wid / 2 + 1.0f * (cameralists[1].orthographicSize) * width / height;
        //position.y = 1f * hei / 2;
        //cameralists[1].transform.position = position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
