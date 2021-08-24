using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RIde_Select_Popup : MonoBehaviour
{
    public Camera camera_;
    public TextMeshProUGUI Ride_Name;
    public TextMeshProUGUI OnCameraObject;
    public TextMeshProUGUI Ride_Status;

    public GameObject Select_Ride;

    void Start()
    {

    }

    void Update()
    {
        if(Select_Ride != null)
        {
            Ride_Name.text = Select_Ride.GetComponent<Ride_State>().Name_this;
            camera_.transform.position = new Vector3(Select_Ride.transform.position.x + 1.75f, Select_Ride.transform.position.y + 3f, Select_Ride.transform.position.z - 2);
        }
    }
}
