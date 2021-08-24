using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ride_State : MonoBehaviour
{
    public bool Place_Check = false;
    public bool IsOpen = false;
    public bool Music = false;
    public string Name_Original, Name_this;
    public float Price, Intensity, interest, Sickness_rate;
    public bool Research_Status, IsEntrance, IsExit;
    public GameObject Entrance, Exit;
    public Texture Image;
    public Camera Camera;
    public List<Vector3> EntExitPosition;
    public AudioSource audio_;

    void Start()
    {
        //audio_ = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayMusic();
    }

    void IsEntranceNExit()
    {
        if(Entrance == null) { IsEntrance = false; }
        else { IsEntrance = true; }
        if(Exit == null) { IsExit = false; }
        else { IsExit = true; }
    }

    public void Ride_Position()
    {
        if (Place_Check == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Debug.Log("현재 선택중인 오브젝트 이름" + hit.collider.gameObject.name + "현재 선택중인 땅의 위치: " + hit.collider.gameObject.transform.position.x + ", " + hit.collider.gameObject.transform.position.y + ", " + hit.collider.gameObject.transform.position.z);
            this.gameObject.transform.position = new Vector3(Mathf.Round(hit.collider.gameObject.transform.position.x), Mathf.Round(hit.collider.gameObject.transform.position.y) + hit.collider.gameObject.transform.localScale.y / 2, Mathf.Round(hit.collider.gameObject.transform.position.z));
        }
        else if (Place_Check == true)
        {
            this.gameObject.transform.position = this.gameObject.transform.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Place_Check = true;
        }
    }

    public void PlayMusic()
    {
        if (Music == true) { audio_.mute = false; }
        else if (Music == false) { audio_.mute = true; }
    }
}
