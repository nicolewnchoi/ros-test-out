using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class drawshapes : MonoBehaviour
{

    public Vector3 point;
    public float radius;
    public Vector2Int startend;
    public bool isgoal;
    public float width = 20;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = point;
        DrawCircle(this.gameObject, 200, radius, width);
        if (isgoal)
        {
            gameMgr.Inst.updateevent.RemoveListener(updateshape);//incase adding multiple events
            gameMgr.Inst.updateevent.AddListener(updateshape);
        }
    }

    void DrawCircle(GameObject object_temp, int steps, float radius, float width)
    {
        int start = startend.x;
        int end = startend.y;

        start = (int)(start / 360.0 * steps);
        end = (int)(end / 360.0 * steps);

        object_temp.GetComponent<LineRenderer>().positionCount = (end-start)+1;
        object_temp.GetComponent<LineRenderer>().startWidth = width;

        for (int i = start; i < end + 1; i++)
        {
            float x = radius * Mathf.Cos((360f / steps * i) * Mathf.Deg2Rad) + object_temp.transform.position.x;
            float y = radius * Mathf.Sin((360f / steps * i) * Mathf.Deg2Rad) + object_temp.transform.position.y;
            object_temp.GetComponent<LineRenderer>().SetPosition(i, new Vector3(x, y, object_temp.transform.position.z));
        }

    }

    void updateshape()
    {
        transform.position = point;
        DrawCircle(this.gameObject, 200, radius*gameMgr.Inst.currentData.goalSize, 20);
    }
}
