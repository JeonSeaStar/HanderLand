using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_edit : MonoBehaviour
{

    //Camera mainCam = null;
    bool mouseState;
    Vector3 Click_MousePos;

    Vector3 MousePos;
    public BuildingList building;
    public GameManager GM;
    RaycastHit hit;
    private bool Edit_start = false;


    void Start()
    {

    }   

    void Update()
    {
        eidtGround();
        OnMouseEnter();
    }
    GameObject selected_object;
    int ground_code = 0;
    int direction = 0;
    Vector3 Parent_Vector = new Vector3(0, 0, 0);
    void eidtGround()
    {
    
        if (GameManager.Ground_EditMode == true)
        {
          
            if (Input.GetMouseButtonDown(0))
            {
                Click_MousePos = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                if (hit.collider.tag == "Ground")
                {
                    Parent_Vector = hit.collider.transform.parent.parent.parent.transform.position;
                   
                    switch (hit.collider.name)
                    {
                        case "quota_0":
                            //not yet
                            break;
                        case "quota_1":
                            //not yet
                            break;
                        case "quota_2":
                            //not yet
                            break;
                        case "quota_3":
                            //not yet
                            break;
                        case "half_0":
                            ground_code = 2;
                            direction = 0;
                            Edit_start = true;
                            break;
                        case "half_1":
                            ground_code = 2;
                            direction = 2;
                            Edit_start = true;
                            break;
                        case "half_2":
                            ground_code = 2;
                            direction = 3;
                            Edit_start = true;
                            break;
                        case "half_3":
                            ground_code = 2;
                            direction = 1;
                            Edit_start = true;
                            break;
                        case "center":
                            ground_code = 1;
                            direction = 0;
                            Edit_start = true;
                            break;
                        default:
                            Edit_start = true;
                            break;
//
                    }
              
                    //ground.GetComponent<Grounddata>().Save_Location_Data(   );
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (Edit_start == true) 
                { 
                        MousePos = Input.mousePosition;
                      Debug.Log(hit.collider.name + "name");
                      if (MousePos.y - Click_MousePos.y >= 5)
                       {
                           if( GM.Check_Upstair(Parent_Vector))
                        {
                            GameObject ground = GM.Ground_LIst[(int)(Parent_Vector.y*2)+1][(int)Parent_Vector.x][(int)Parent_Vector.z];
                            ground.GetComponent<Grounddata>().Build_code = ground_code;
                            Debug.Log("빌드코드까지옴");
                            ground.GetComponent<Grounddata>().Direction_Change(direction);
                        }
                           Debug.Log("블럭 생성");


                        }
                      else if (Click_MousePos.y - MousePos.y >= 5)
                       {

                        if (GM.Check_Downstair(Parent_Vector)==true)
                        {
                            GM.Destroy_Ground(new Vector3());
                        }
                        Debug.Log("블럭 삭제");
                           Destroy(hit.transform.gameObject);
                       }
                }
                
              
            }
            if (Input.GetMouseButtonUp(0))
            {
                Edit_start = false;
                ground_code = 0;
                direction = 0;
                Parent_Vector = new Vector3(0, 0, 0);

            }
        }
    }

    void OnMouseEnter()
    {

    }
}
