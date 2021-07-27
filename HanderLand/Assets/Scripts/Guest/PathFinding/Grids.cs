using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids : MonoBehaviour
{
    public List<Node[,]> GridList = new List<Node[,]>();
    public Vector3 StartPosition;
    public LayerMask RoadMask;
    public float SphereRadius, SphereDiameter, SphereDistance;
    public int worldX, worldY, worldZ;
    public List<Node> FinalPath;

    void Start()
    {
        SphereDiameter = SphereRadius * 2;
        //CreateGrid();
    }

    void Update()
    {

    }

    public void CreateGrid()
    {
        GridList = new List<Node[,]>();
        for (int y = 0; y < worldY; y++) 
        {
            GridList.Add(new Node[worldX, worldZ]);
            for (int x = 0; x < worldX; x++)
            {
                for (int z = 0; z < worldZ; z++)
                {
                    Vector3 NodePosition = new Vector3(x, y / 2f, z);
                    bool Road = false;

                    if(Physics.CheckSphere(NodePosition, SphereRadius, RoadMask))
                    {
                        Road = true;
                    }
                    GridList[y][x, z] = new Node(x, y, z, NodePosition, Road);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(worldX / 2 - 0.5f, worldY / 4 + 0.25f, worldZ / 2 - 0.5f), new Vector3(worldX, worldY / 2, worldZ));

        if(Application.isPlaying)
        {
            if (GridList != null)
            {
                for (int y = 0; y < worldY; y++)
                {
                    for (int x = 0; x < worldX; x++)
                    {
                        for (int z = 0; z < worldZ; z++)
                        {
                            if (GridList[y][x, z].IsRoad == false)
                            {
                                Gizmos.color = Color.yellow;
                            }
                            else if (GridList[y][x, z].IsRoad == true)
                            {
                                Gizmos.color = Color.white;
                            }

                            if (FinalPath != null)
                            {
                                if (FinalPath.Contains(GridList[y][x, z]))
                                {
                                    Gizmos.color = Color.red;
                                }
                            }

                            if (this.gameObject.GetComponent<PathFinding>().CloseNode != null)
                            {
                                if (this.gameObject.GetComponent<PathFinding>().CloseNode.Contains(GridList[y][x, z]))
                                {
                                    Gizmos.color = Color.blue;
                                }
                            }
                            Gizmos.DrawSphere(GridList[y][x, z].NodePosition, SphereRadius);
                        }
                    }
                }
            }
        }
    }
}
