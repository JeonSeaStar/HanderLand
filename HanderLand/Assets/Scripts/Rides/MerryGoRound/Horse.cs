using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public bool UPnDOWN; //false = down, true = up

    void Start()
    {
        
    }

    void Update()
    {
        UpDown();
    }

    void UpDown()
    {
        if (transform.localPosition.y >= 0.6f)
        {
            UPnDOWN = false;
        }
        else if (transform.localPosition.y <= 0.4f)
        {
            UPnDOWN = true;
        }
    }
}
