using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ride_Select : MonoBehaviour
{
    public Camera Camera;
    public GameObject[] Popup;
    public GameObject[] Button;
    public GameObject Rides_Place_Popup;
    
    public GameObject[] JanJanBaRi_Rides;
    public GameObject[] JanJanBaRi_state;
    public GameObject[] Excited_Rides;
    public GameObject[] Excited_state;
    public GameObject[] RC_Rides;
    public GameObject[] RC_state;
    public GameObject[] Shop_Rides;
    public GameObject[] Shop_state;

    void Start()
    {
        Ride_();
    }

    void Update()
    {
        
    }

    public void Close_Popup()
    {
        this.gameObject.SetActive(false);
    }

    public void Open_JanJanBaRi()
    {
        Popup[0].SetActive(true);
        Popup[1].SetActive(false);
        Popup[2].SetActive(false);
        Popup[3].SetActive(false);

        Button[0].SetActive(false);
        Button[1].SetActive(true);
        Button[2].SetActive(true);
        Button[3].SetActive(true);
    }

    public void Open_Excited()
    {
        Popup[0].SetActive(false);
        Popup[1].SetActive(true);
        Popup[2].SetActive(false);
        Popup[3].SetActive(false);

        Button[0].SetActive(true);
        Button[1].SetActive(false);
        Button[2].SetActive(true);
        Button[3].SetActive(true);
    }

    public void Open_RollerCoaster()
    {
        Popup[0].SetActive(false);
        Popup[1].SetActive(false);
        Popup[2].SetActive(true);
        Popup[3].SetActive(false);

        Button[0].SetActive(true);
        Button[1].SetActive(true);
        Button[2].SetActive(false);
        Button[3].SetActive(true);
    }

    public void Open_Shop()
    {
        Popup[0].SetActive(false);
        Popup[1].SetActive(false);
        Popup[2].SetActive(false);
        Popup[3].SetActive(true);

        Button[0].SetActive(true);
        Button[1].SetActive(true);
        Button[2].SetActive(true);
        Button[3].SetActive(false);
    }

    void Ride_()
    {
        for(int i = 0; i < JanJanBaRi_Rides.Length; i++)
        {
            JanJanBaRi_state[i].GetComponent<Ride_State_Button>().Ride = JanJanBaRi_Rides[i];
            JanJanBaRi_state[i].transform.GetChild(0).GetComponent<RawImage>().texture = JanJanBaRi_Rides[i].GetComponent<Ride_State>().Image;
            JanJanBaRi_state[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "$ " + JanJanBaRi_Rides[i].GetComponent<Ride_State>().Price.ToString();
            JanJanBaRi_state[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = JanJanBaRi_Rides[i].GetComponent<Ride_State>().Name_Original;
        }

        for (int i = 0; i < Excited_Rides.Length; i++)
        {
            Excited_state[i].GetComponent<Ride_State_Button>().Ride = Excited_Rides[i];
            Excited_state[i].transform.GetChild(0).GetComponent<RawImage>().texture = Excited_Rides[i].GetComponent<Ride_State>().Image;
            Excited_state[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "$ " + Excited_Rides[i].GetComponent<Ride_State>().Price.ToString();
            Excited_state[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Excited_Rides[i].GetComponent<Ride_State>().Name_Original;
        }

        for (int i = 0; i < RC_Rides.Length; i++)
        {
            RC_state[i].GetComponent<Ride_State_Button>().Ride = RC_Rides[i];
            RC_state[i].transform.GetChild(0).GetComponent<RawImage>().texture = RC_Rides[i].GetComponent<Ride_State>().Image;
            RC_state[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "$ " + RC_Rides[i].GetComponent<Ride_State>().Price.ToString();
            RC_state[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = RC_Rides[i].GetComponent<Ride_State>().Name_Original;
        }

        for (int i = 0; i < Shop_Rides.Length; i++)
        {
            Shop_state[i].GetComponent<Ride_State_Button>().Ride = Shop_Rides[i];
            Shop_state[i].transform.GetChild(0).GetComponent<RawImage>().texture = Shop_Rides[i].GetComponent<Ride_State>().Image;
            Shop_state[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "$ " + Shop_Rides[i].GetComponent<Ride_State>().Price.ToString();
            Shop_state[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Shop_Rides[i].GetComponent<Ride_State>().Name_Original;
        }
    }
}
