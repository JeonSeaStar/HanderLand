using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerryGoRound : Ride_State
{
    public GameObject[] horse;
    public GameObject ride;
    public GameObject[] Parts;
    public Material[] materials;
    public Material NoPlaceMaterial;
    public float Speed_Rotate, Speed_PAK;

    void Start()
    {
        if(Place_Check == false)
        {
            NoPlace();
        }

        rideColor();
    }

    void Update()
    {
        if (Place_Check == true)
        {
            Rotate();
            Pak();
        }
        //Rotate();
        //Pak();
        if (Place_Check == false && Input.GetMouseButtonDown(0)) { SetAblePosition(); }
        Ride_Position();
    }

    void Rotate()
    {
        ride.transform.eulerAngles = new Vector3(0, ride.transform.eulerAngles.y + Speed_Rotate * Time.deltaTime, 0);
    }

    void Pak()
    {
        for(int i = 0; i < horse.Length; i++)
        {
            Vector3 DownPos = new Vector3(horse[i].transform.position.x, transform.position.y + 0, horse[i].transform.position.z);
            Vector3 UpPos = new Vector3(horse[i].transform.position.x, transform.position.y + 1, horse[i].transform.position.z);

            Horse h = horse[i].GetComponent<Horse>();

            if (h.UPnDOWN == false)
            {
                horse[i].transform.position = Vector3.MoveTowards(horse[i].transform.position, DownPos, Speed_PAK * Time.deltaTime);
            }
            else if (h.UPnDOWN == true)
            {
                horse[i].transform.position = Vector3.MoveTowards(horse[i].transform.position, UpPos, Speed_PAK * Time.deltaTime);
            }
        }
    }

    void NoPlace()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            Parts[i].GetComponent<Renderer>().material = NoPlaceMaterial;
        }
    }

    void SetAblePosition()
    {
        Debug.Log("¹èÄ¡ÇÔ");
        Vector3 AblePosition;
        EntExitPosition = new List<Vector3>();

        AblePosition = this.transform.position;
        AblePosition.x -= 3;
        AblePosition.z -= 3;
        for (int i = 0; i < 5; i++)
        {
            AblePosition.z += 1;
            EntExitPosition.Add(AblePosition);
        }

        AblePosition = this.transform.position;
        AblePosition.x -= 3;
        AblePosition.z += 3;
        for (int i = 0; i < 5; i++)
        {
            AblePosition.x += 1;
            EntExitPosition.Add(AblePosition);
        }

        AblePosition = this.transform.position;
        AblePosition.x += 3;
        AblePosition.z -= 3;
        for (int i = 0; i < 5; i++)
        {
            AblePosition.z += 1;
            EntExitPosition.Add(AblePosition);
        }

        AblePosition = this.transform.position;
        AblePosition.x -= 3;
        AblePosition.z -= 3;
        for (int i = 0; i < 5; i++)
        {
            AblePosition.x += 1;
            EntExitPosition.Add(AblePosition);
        }
    }

    void rideColor()
    {
        Material aa = new Material(materials[0]);
        Material bb = new Material(materials[1]);
        Material cc = new Material(materials[2]);
        Material dd = new Material(materials[3]);
        Material ee = new Material(materials[4]);


        for (int i = 0; i < Parts.Length; i++)
        {
            if (i >= 0 && i < 2) { Parts[i].GetComponent<Renderer>().material = aa; }
            else if (i >= 2 && i < 5) { Parts[i].GetComponent<Renderer>().material = bb; }
            else if (i >= 5 && i < 13) { Parts[i].GetComponent<Renderer>().material = cc; }
            else if (i >= 13 && i < 21) { Parts[i].GetComponent<Renderer>().material = dd; }
            else if (i >= 21 && i < 29) { Parts[i].GetComponent<Renderer>().material = ee; }
            else if (i >= 29 && i < Parts.Length) { Parts[i].GetComponent<Renderer>().material = bb; }
        }
    }
}
