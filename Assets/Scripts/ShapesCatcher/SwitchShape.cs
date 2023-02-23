using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchShape : MonoBehaviour
{
    [SerializeField] public Sprite[] boundaries; 
    private void Update()
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().size = new Vector2(13.5f, 13.5f);
        if (transform.position.x < 768) // left of center
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeShape();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                ChangeShape();
            }
        }
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
