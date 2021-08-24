using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoaster : MonoBehaviour
{
    public List<GameObject> Rail = new List<GameObject>();
    public List<List<Point>> track = new List<List<Point>>();
    public GameObject train;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Track()
    {
        track = new List<List<Point>>();
        for (int i = 0; i < Rail.Count; i++)
        {
            track.Add(Rail[i].GetComponent<Path>().path);
        }
    }
}
