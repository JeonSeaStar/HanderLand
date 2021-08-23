using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    // Start is called before the first frame update
    public float width = 1;
    public float height = 1;
    public enum Triangle_mode
    {
        Tri_default,
        Tri_2,
        Tri_3
    }
    public Triangle_mode Tri = Triangle_mode.Tri_default;
    public void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
        
        mesh.Clear();   
        switch(Tri)
        {
            case Triangle_mode.Tri_default:
                mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
                mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
                mesh.triangles = new int[] { 0, 1, 2 };
                break;
            case Triangle_mode.Tri_2:
                mesh.vertices = new Vector3[] { new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(0.5f, 0.5f, -0.5f), new Vector3(-0.5f, -0.5f, -0.5f) };
                mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
                mesh.triangles = new int[] { 0, 1, 2 };
                break;
            case Triangle_mode.Tri_3:
                mesh.vertices = new Vector3[] { new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0.5f, 0.5f, -0.5f) };
                mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
                mesh.triangles = new int[] { 0, 1, 2 };
                break;

        }

    }

}


