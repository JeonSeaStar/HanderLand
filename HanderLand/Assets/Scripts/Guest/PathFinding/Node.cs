using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int GridX, GridY, GridZ;
    public bool IsRoad;
    public Vector3 NodePosition;
    public Node ParentNode;

    public int gCost, hCost;
    public int fCost { get { return hCost + gCost; } } 

    public Node(int GridX, int GridY, int GridZ, Vector3 NodePosition, bool IsRoad)
    {
        this.GridX = GridX;
        this.GridY = GridY;
        this.GridZ = GridZ;
        this.NodePosition = NodePosition;
        this.IsRoad = IsRoad;
    }
}
