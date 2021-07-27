using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_edit : MonoBehaviour
{
    //Camera mainCam = null;
    bool mouseState;
    Vector3 Click_MousePos;
    Vector3 MousePos;
    public GameObject Ground_Center;
    RaycastHit hit;

    void Start()
    {

    }

    void Update()
    {
        eidtGround();
        OnMouseEnter();
    }

    void eidtGround()
    {
        if (GameManager.Ground_EditMode == true)
        {

            if(Input.GetMouseButtonDown(0))
            {
                Click_MousePos = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
            }

            if(Input.GetMouseButton(0))
            {
                if (hit.collider.tag == "Ground_Center")
                {
                    MousePos = Input.mousePosition;
                    if (MousePos.y - Click_MousePos.y >= 1)
                    {
                        Debug.Log("블럭 생성");
                        Instantiate(Ground_Center, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 0.5f, hit.collider.transform.position.z), Quaternion.identity);
                    }
                    else if(Click_MousePos.y - MousePos.y >= 1)
                    {
                        Debug.Log("블럭 삭제");
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }

    void OnMouseEnter()
    {

    }
}
