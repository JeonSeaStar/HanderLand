using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rides_Place : MonoBehaviour
{
    public GameObject Ride;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Price;
    public RawImage Image;
    public GameObject Prefab_Entrance, Prefab_Exit;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void close()
    {
        Ride = null;
        this.gameObject.SetActive(false);
    }

    public void State()
    {
        Image.texture = Ride.GetComponent<Ride_State>().Image;
        Name.text = "\" " + Ride.GetComponent<Ride_State>().Name_this + " \"";
        Price.text = "$ " + Ride.GetComponent<Ride_State>().Price.ToString();
    }

    public void Place_Entarnce()
    {
        GameObject Entrance = Instantiate(Prefab_Entrance, Ride.transform.position, Quaternion.identity);
        Entrance.transform.parent = Ride.transform;
        Ride.GetComponent<Ride_State>().Entrance = Entrance;
    }

    public void Place_Exit()
    {
        GameObject Exit = Instantiate(Prefab_Exit, Ride.transform.position, Quaternion.identity);
        Exit.transform.parent = Ride.transform;
        Ride.GetComponent<Ride_State>().Entrance = Exit;
    }
}
