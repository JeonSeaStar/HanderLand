using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rename_Popup : MonoBehaviour
{
    public GameObject Rename_Guest;
    public TextMeshProUGUI ChangeName;

    void Update()
    {
        
    }

    public void Change_Name()
    {
        Rename_Guest.gameObject.name = ChangeName.text;

        ChangeName.text = null;
        this.gameObject.SetActive(false);
    }

    public void Close_Popup()
    {
        ChangeName = null;
        this.gameObject.SetActive(false);
    }
}
