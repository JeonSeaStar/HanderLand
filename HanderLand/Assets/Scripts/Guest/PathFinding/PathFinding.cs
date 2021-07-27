using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public GameObject TargetNode_;
    public List<Node> FinalPath = new List<Node>();
    public List<Node> CloseNode = new List<Node>();
    public Node CurrentNode;

    public void pathfinding(Node StartNode, Node TargetNode)
    {
        CloseNode.Add(StartNode);
        CurrentNode = StartNode;
        List<Node> Neighbor = NeighborNode(CurrentNode);
        Node MinFCost = null;
        MinFCost = Neighbor[0];
        MinFCost.hCost = ManhattanDistance(MinFCost, StartNode);
        MinFCost.gCost = ManhattanDistance(MinFCost, TargetNode);
        for (int i = 0; i < Neighbor.Count; i++)
        {
            for (int j = 0; j < CloseNode.Count; j++)
            {
                if(Neighbor[i].NodePosition == CloseNode[j].NodePosition && Neighbor[i] == CurrentNode.ParentNode)
                {
                    Neighbor.RemoveAt(i);
                    i = 0;
                    if(Neighbor.Count == 0)
                    {
                        DeleteParents();
                        CloseNode.Add(CurrentNode.ParentNode);
                    }
                }
            }
        }
        for (int i = 0; i < Neighbor.Count; i++)
        {
            Neighbor[i].hCost = ManhattanDistance(Neighbor[i], StartNode);
            Neighbor[i].gCost = ManhattanDistance(Neighbor[i], TargetNode);
            if (MinFCost.fCost >= Neighbor[i].fCost) { MinFCost = Neighbor[i]; }
        }
        MinFCost.ParentNode = CurrentNode;
        CurrentNode = MinFCost;
        FinalPath.Add(CurrentNode);
        CloseNode.Add(CurrentNode);
        UpdateFinalPath();
    }

    public Node posStart(GameObject gameObject)
    {
        Vector3 PosStart = new Vector3(Mathf.Round(gameObject.transform.position.x), (gameObject.transform.position.y - 0.45f) / 0.5f, Mathf.Round(gameObject.transform.position.z));
        int x = (int)PosStart.x;
        int y = (int)PosStart.y + 1;
        int z = (int)PosStart.z;
        Node NodeStart = this.GetComponent<Grids>().GridList[y][x, z];

        return NodeStart;
    }

    public Node posTarget(GameObject gameObject)
    {
        Vector3 PosTarget = new Vector3(Mathf.Round(gameObject.transform.position.x), gameObject.transform.position.y, Mathf.Round(gameObject.transform.position.z));
        float xx = 0.25f * gameObject.transform.localScale.y;
        PosTarget.y = xx / 0.25f * 0.25f;
        int x = (int)PosTarget.x;
        int y = (int)PosTarget.y + 1;
        int z = (int)PosTarget.z;
        Node NodeTarget = this.GetComponent<Grids>().GridList[y][x, z];
        
        return NodeTarget;
    }
    
    public List<Node> NeighborNode(Node Current)
    {
        List<Node> Neighbor = new List<Node>();
        Node LeftNode, RightNode, ForwardNode, BackNode;
        int x;
        float yy = Current.NodePosition.y * 2;
        int y = (int)yy;
        int z;

        x = (int)Current.NodePosition.x;
        z = (int)Current.NodePosition.z + 1;
        if(x + z < GetComponent<Grids>().GridList[y].Length)
        {
            LeftNode = this.GetComponent<Grids>().GridList[y][x, z];
            if(LeftNode.IsRoad == true)
            {
                Neighbor.Add(LeftNode);
            }
        }

        x = (int)Current.NodePosition.x - 1;
        z = (int)Current.NodePosition.z;
        if (x + z < GetComponent<Grids>().GridList[y].Length && x >= 0)
        {
            RightNode = this.GetComponent<Grids>().GridList[y][x, z];
            if (RightNode.IsRoad == true)
            {
                Neighbor.Add(RightNode);
            }
        }

        x = (int)Current.NodePosition.x;
        z = (int)Current.NodePosition.z - 1;
        if (x + z < GetComponent<Grids>().GridList[y].Length && z >= 0)
        {
            ForwardNode = this.GetComponent<Grids>().GridList[y][x, z];
            if (ForwardNode.IsRoad == true)
            {
                Neighbor.Add(ForwardNode);
            }
        }

        x = (int)Current.NodePosition.x + 1;
        z = (int)Current.NodePosition.z;
        if (x + z < GetComponent<Grids>().GridList[y].Length)
        {
            BackNode = this.GetComponent<Grids>().GridList[y][x, z];
            if (BackNode.IsRoad == true)
            {
                Neighbor.Add(BackNode);
            }
        }

        return Neighbor;
    }

    void UpdateFinalPath()
    {
        this.GetComponent<Grids>().FinalPath = FinalPath;
        this.GetComponent<Guest>().Path = FinalPath;
    }

    public void DeleteParents()
    {
        CloseNode = new List<Node>();
        int worldX = this.transform.GetComponent<Grids>().worldX;
        int worldY = this.transform.GetComponent<Grids>().worldY;
        int worldZ = this.transform.GetComponent<Grids>().worldZ;
        for (int y = 0; y < worldY; y++)
        {
            for (int x = 0; x < worldX; x++)
            {
                for (int z = 0; z < worldZ; z++)
                {
                    this.transform.GetComponent<Grids>().GridList[y][x, z].ParentNode = null;
                }
            }
        }
    }

    int ManhattanDistance(Node Current, Node Target)
    {
        int x = Mathf.Abs(Current.GridX - Target.GridX);
        int z = Mathf.Abs(Current.GridZ - Target.GridZ);

        return x + z;
    }
}
