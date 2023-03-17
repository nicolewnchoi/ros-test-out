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

public class posmessageSC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectbase;
    public List<GameObject> objects;
    public List<float> x;
    public List<float> y;
    public List<float> r;
    public List<bool> pastButton;

    //for debug
    public Text text;
    public Text text2;
    public Text text3;

    //for store weather kick button ispressed
    bool[] kickbutton;

    //unity service name
    string m_ServiceName = "unity_srv";


    [SerializeField] public Sprite[] boundaries;
    private void Awake()
    {
        
        
    }

    void Start()
    {
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    void posChange(RosPos rosPos)
    {
        float projector_height = 1024;
        float projector_width = 768;
        float cv_width = 960f;
        float cv_height = 640f;

        float perspective_x = 2 * projector_width / cv_width;
        float perspective_y = projector_height / cv_height;  //same

        int player_num = rosPos.total;

        while (objects.Count < player_num)
        {
            objects.Add(Instantiate(objectbase));
            x.Add(0);
            y.Add(0);
            r.Add(0);
        }

        while (objects.Count > player_num)
        {
            Destroy(objects[objects.Count - 1]);
            objects.Remove(objects[objects.Count - 1]);
            x.Remove(x[x.Count - 1]);
            y.Remove(y[y.Count - 1]);
            r.Remove(r[r.Count - 1]);
        }


        for (int i = 0; i < player_num; i++)
        {
            x[i] = (float)rosPos.x[i] * perspective_x;
            y[i] = (float)rosPos.y[i] * perspective_y;
            r[i] = (float)rosPos.size[i] * perspective_x;

            var pos1 = new Vector3(x[i], y[i], 0);
            objects[i].transform.position = pos1;

            //if is kicked set the size to a abosolute
            //determine whether it's pressed for a long time
            //if (kickbutton.Length == player_num && kickbutton[i]) //subject to change
            //{
            //    r[i] = 500; //need change later when we get gamemanager
            //}
            //else 

            //if (kickbutton.Length == 2) //need change after getting the ground size
            //{
            //    if (x[i] <= projector_width && kickbutton[0])
            //    {
            //        r[i] = 500;
            //    }
            //    else if(x[i] >= projector_width && kickbutton[1])
            //    {
            //        r[i] = 500;
            //    }

            //}
            //else if (kickbutton.Length == 1) //Length==32 so it's wrong!!!
            //{
            //    Debug.Log("aaaaa\n");
            //    r[i] = 50; //need change after discussing about game mechanisms
            //}

            //for testing only 2/22
            //objectbase.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().size = new Vector2(13.5f, 13.5f);
            objects[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().size = new Vector2(.1f, .1f) * r[i];

            if (kickbutton.Length != 0 && kickbutton[0])
            {
                ChangeShape(); //subject to change
            }

            //add sth about pastButton
            //pastButton[i] = kickbutton[i];

            //update the collider
        }


        //var x = (float)rosPos.x[0];
        //var y = (float)rosPos.y[0];
        //var pos = Camera.main.ScreenToWorldPoint(new Vector3(x, y,Camera.main.nearClipPlane));//convert to normal coordinate
        // pos.z = 0;
        Debug.Log(rosPos.total + " and " + rosPos.x[0] + " and " + rosPos.y[0] + "and" + rosPos.size);
        // Debug.Log(rosPos.total);
        // Debug.Log(rosPos.size[0] + "and" + rosPos.size[1] +"and"+ rosPos.size[2]);
    }
    void kickChange(RosButton kicksize)
    {
        kickbutton = kicksize.kick;

        Debug.Log(kickbutton[0].ToString());
    }

    rosAirHockyreturnData currentStatus(rosAirHockyinData inData)
    {
        return gameMgr.Inst.tryUpdate(inData);
    }

    private void ChangeShape()
    {
        for (int i = 0; i < boundaries.Length; ++i)
        {
            if (transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == boundaries[i])
            {
                if (i + 1 >= boundaries.Length)
                {
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = boundaries[0];
                    break;
                }
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = boundaries[i + 1];
                break;
            }
        }
    }

}