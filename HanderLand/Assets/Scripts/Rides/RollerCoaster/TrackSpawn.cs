using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    public GameObject Track01, Track02, Track03;
    public float x,y,z;

    public void Spawn_01()
    {
        GameObject track = Instantiate(Track01, new Vector3(x,y,z), Quaternion.identity);
        track.transform.parent = transform;
        z++;
        transform.GetComponent<RollerCoaster>().Rail.Add(track);
        transform.GetComponent<RollerCoaster>().Track();
        transform.GetComponent<RollerCoaster>().train.GetComponent<Trains>().UpdatePath();
    }

    public void Spawn_02()
    {
        GameObject track = Instantiate(Track02, new Vector3(x, y, z), Quaternion.identity);
        track.transform.parent = transform;
        z++;
        y += 0.5f;
        transform.GetComponent<RollerCoaster>().Rail.Add(track);
        transform.GetComponent<RollerCoaster>().Track();
        transform.GetComponent<RollerCoaster>().train.GetComponent<Trains>().UpdatePath();
    }

    public void Spawn_03()
    {
        GameObject track = Instantiate(Track03, new Vector3(x, y, z), Quaternion.identity);
        track.transform.parent = transform;
        z += 2f;
        y += 2.5f;
        transform.GetComponent<RollerCoaster>().Rail.Add(track);
        transform.GetComponent<RollerCoaster>().Track();
        transform.GetComponent<RollerCoaster>().train.GetComponent<Trains>().UpdatePath();
    }
}