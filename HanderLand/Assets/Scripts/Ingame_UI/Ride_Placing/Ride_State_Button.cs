using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ride_State_Button : MonoBehaviour
{
    public GameObject SelectPU;
    public GameObject PlacePU;
    public GameObject Ride;
    
    void Start()
    {
        SelectPU = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.transform.parent.gameObject;
        PlacePU = SelectPU.GetComponent<Ride_Select>().Rides_Place_Popup;
    }

    public void Place_Ride()
    {
        PlacePU.GetComponent<Rides_Place>().Ride = Ride;
        GameObject Place_Ride = Instantiate(Ride, new Vector3(0, 0, 0), Quaternion.identity);
        Place_Ride.GetComponent<Ride_State>().Camera = SelectPU.GetComponent<Ride_Select>().Camera;
        Place_Ride.GetComponent<Ride_State>().Name_this = Place_Ride.GetComponent<Ride_State>().Name_Original;
        PlacePU.GetComponent<Rides_Place>().State();
        SelectPU.SetActive(false);
        PlacePU.SetActive(true);
    }
}
