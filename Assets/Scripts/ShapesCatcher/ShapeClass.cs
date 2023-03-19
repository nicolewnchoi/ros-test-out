using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeClass : MonoBehaviour
{
    public enum Shape
    {
        CIRCLE = 0,
        SQUARE = 1,
        TRIANGLE = 2
    }

    public Shape shape;
}
