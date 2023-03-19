using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchShape : MonoBehaviour
{
    //[SerializeField] public Sprite[] boundaries;
    public int shapesCount = 3;

    private void Update()
    {
        //transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().size = new Vector2(13.5f, 13.5f);
        if (transform.position.x < 768) // left of center
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeShape(gameObject);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                ChangeShape(gameObject);
            }
        }
    }

    private void ChangeShape(GameObject object_temp)
    {
        if ((int)object_temp.GetComponent<ShapeClass>().shape == shapesCount - 1)
        {
            object_temp.GetComponent<ShapeClass>().shape = 0;
            return;
        }
        object_temp.GetComponent<ShapeClass>().shape++;
    }
}