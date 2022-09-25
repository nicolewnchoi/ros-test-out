using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosPos = RosMessageTypes.ApInterfaces.PosMsg;

public class posmessage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectbase;
    public List<GameObject> objects;
    public List<float> x;
    public List<float> y;
    public List<float> r;
    private void Awake()
    {
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }

    void Start()
    {
        //objects1.SetActive(true); //test for DrawCircle
        //objects1.transform.position = new Vector3(3f, 4f, 0f);
        //objects2.transform.position = new Vector3(0f, 4f, 0f);
        //DrawCircle(objects1, 200, 1.5f, 0.2f);
        //DrawCircle(objects2, 200, 0.7f, 0.2f);
        ROSConnection.GetOrCreateInstance().Subscribe<RosPos>("pos_raw", posChange);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void posChange(RosPos rosPos)
    {

        int player_num = rosPos.total;
        float cv_width = 960f;
        float cv_height = 640f;
        float projector_height = 1024;
        float projector_width = 768;
        float perspective_x = 2 * projector_width / cv_width;
        float perspective_y = projector_height / cv_height;

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
            objects.RemoveAt(objects.Count - 1);
            x.RemoveAt(x.Count - 1);
            y.RemoveAt(y.Count - 1);
            r.RemoveAt(r.Count - 1);
        }

        for (int i = 0; i < player_num; i++)
        {
            x[i] = (float)rosPos.x[i] * perspective_x;
            y[i] = (float)rosPos.y[i] * perspective_y;
            r[i] = (float)rosPos.size[i] * perspective_x * 1.5f;

            var pos1 = new Vector3(x[i], y[i], 0);
            //pos1.z = 0;
            objects[i].transform.position = pos1;
            DrawCircle(objects[i], 200, r[i], 10f);

        }


        //var x = (float)rosPos.x[0];
        //var y = (float)rosPos.y[0];
        //var pos = Camera.main.ScreenToWorldPoint(new Vector3(x, y,Camera.main.nearClipPlane));//convert to normal coordinate
        // pos.z = 0;
        Debug.Log(rosPos.total + " and " + rosPos.x[0] + " and " + rosPos.y[0] + "and" + rosPos.size);
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

    Vector3 Normlization(Vector3 worldpoint)
    {
        Vector3 normlized_point;
        normlized_point.x = worldpoint.x / worldpoint.z;
        normlized_point.y = worldpoint.y / worldpoint.z;
        normlized_point.z = 0;
        return normlized_point;
    }
}
