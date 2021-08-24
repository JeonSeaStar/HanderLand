using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
    public Vector3 position;
    public Vector3 rotation;
    public int type;

    public Point(Vector3 position, Vector3 rotation, int type)
    {
        this.position = position;
        this.rotation = rotation;
        this.type = type;
    }
}
