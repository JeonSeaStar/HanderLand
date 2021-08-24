using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Point> path = new List<Point>();
    public GameObject[] wood;

    void Update()
    {
        WayPoint_position();
    }

    void WayPoint_position()
    {
        for (int i = 0; i < wood.Length; i++)
        {
            path[i].position = new Vector3(wood[i].transform.position.x, wood[i].transform.position.y + 0.5f, wood[i].transform.position.z);
            path[i].rotation = new Vector3(wood[i].transform.eulerAngles.x, wood[i].transform.eulerAngles.y, wood[i].transform.eulerAngles.z);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for(int i = 0; i < path.Count; i++)
        {
            Gizmos.DrawSphere(path[i].position, 0.1f);
        }
    }
}
