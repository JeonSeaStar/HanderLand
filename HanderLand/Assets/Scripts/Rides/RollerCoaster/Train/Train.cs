using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Train
{
    public GameObject train;
    public Vector3 position;
    public Vector3 rotation;
    
    public Train(GameObject train, Vector3 position, Vector3 rotation)
    {
        train = this.train;
        position = this.position;
        rotation = this.rotation;
    }
}
