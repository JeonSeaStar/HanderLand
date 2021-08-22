using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Ground;
    public GameObject guest;
    public GameObject Rename_Popup;
    public GameObject Ride_Select_Popup;
    public int Guest_Num = 0;
    public int x, z;
    public static bool Ground_EditMode = false;
    public GameObject[] Guest_Select_Popup = new GameObject[6];
    public GameObject[] Select_Guest = new GameObject[6];
    public bool[] Guest_Select = new bool[6];
    Vector3 Click_MousePos, MousePos;
    RaycastHit hit;
    public int Camera_Mode = 0;
    public GameObject[] Camera_Tracking;
    public float Camera_Speed;
    public GameObject[] Base_Point;
    public Camera Camera_Main;
    public TextMeshProUGUI Park_Name_text, Park_Grade_text, Park_Guest_text, Park_Money_text, Park_Date_text, Park_Time_text, Park_Temperature_text;
    public string Park_Name, Park_Date, Park_Time;
    public int Park_Grade, Park_Guest,Park_Date_Year, Park_Date_Month, Park_Date_Day, Park_Temperature;
    public float Park_Money, Park_Time_Hour, Park_Time_Min;
    public float Camera_Size = 10;

    public List<GameObject> Target;
    public List<List<List<GameObject>>> Ground_LIst;




    //에반데 좀더 괜찮은거 찾아봐야될듯
    void Start()
    {
        Physics.IgnoreLayerCollision(9, 11);
        Ground_Spawn(x, z);
    }

    void Update()
    {
        Select();
        Camera_Position();
    }

    void Ground_Spawn(int x, int z) // 생성할 월드의 x축 길이, y축 높이 z축 길이
    {
        Ground_LIst = new List<List<List<GameObject>>>();
        int y = x > z ? x : z;
        for (int k = 0; k < y; k++)
        {
            Ground_LIst.Add(new List<List<GameObject>>());
            Vector3 Ground_Pos = new Vector3(0, ((float)k)/2, 0);
            for (int i = 0; i < x; i++)
            {
                Ground_LIst[k].Add(new List<GameObject>());
                for (int j = 0; j < z; j++)
                {
                    
                    Ground = Instantiate(Ground, Ground_Pos, Quaternion.identity);
                    
                    Ground.GetComponent<Grounddata>().Save_Location_Data(i, k, j);
                    Ground.name = ("Ground[" + i + " , " +k + " , " + j + "]");
                    Ground.transform.parent = this.transform;
                    Ground_LIst[k][i].Add(Ground);
                    Ground_Pos.z++; //블럭의 z 크기만큼    
                }
                Ground_Pos.z = 0;
                Ground_Pos.x++; //블럭의 x 크기만큼
               
            }
        }
       
    }

    public void guest_spawn()
    {
        guest = Instantiate(guest, new Vector3(0, 0.45f, 0), Quaternion.identity);
        guest.name = ("Guest[" + Guest_Num + "]");
        //guest.GetComponent<Guest>().speed = Random.Range(1, 6);
        Guest_Num += 1;
    }

    public void Ground_Edit()
    {
        if(Ground_EditMode == false)
        {
            Ground_EditMode = true;
            Debug.Log("지형 편집모드 ON");
        }
        else if(Ground_EditMode == true)
        {
            Ground_EditMode = false;
            Debug.Log("지형 편집모드 OFF");
        }
    }

    void Select()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click_MousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 1<<9);

            if(hit.collider != null)
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("guest"))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (Guest_Select[i] == false)
                        {
                            Guest_Select[i] = true;
                            Select_Guest[i] = hit.collider.gameObject;
                            Guest_Select_Popup[i].gameObject.SetActive(true);
                            break;
                        }
                        else { continue; }
                    }
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }

    void Camera_Position()
    {
        if(Camera_Size < 5) { Camera_Size = 5; }
        if(Camera_Size > 30) { Camera_Size = 30; }

        int speed = 10;
        Camera_Size -= Input.GetAxis("Mouse ScrollWheel") * speed;
        Camera_Main.GetComponent<Camera>().orthographicSize = Camera_Size;

        Base_Point[1].transform.position = Base_Point[0].transform.position;

        if (Rename_Popup.activeSelf == false)
        {
            switch (Camera_Mode)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.Q)) { Camera_Mode = 1; }
                    else if (Input.GetKeyDown(KeyCode.E)) { Camera_Mode = 3; }

                    Base_Point[1].transform.eulerAngles = new Vector3(45, 315, 0);

                    for (int i = 0; i < 6; i++)

                    {
                        if (Select_Guest[i] != null)
                        {
                            Camera_Tracking[i].transform.position = new Vector3(Select_Guest[i].transform.position.x + 1.5f, Select_Guest[i].transform.position.y + 2.5f, Select_Guest[i].transform.position.z - 1.5f);
                            Camera_Tracking[i].transform.eulerAngles = new Vector3(45, 315, 0);
                        }
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.Q)) { Camera_Mode = 2; }
                    else if (Input.GetKeyDown(KeyCode.E)) { Camera_Mode = 0; }

                    Base_Point[1].transform.eulerAngles = new Vector3(45, 45, 0);

                    for (int i = 0; i < 6; i++)
                    {
                        if (Select_Guest[i] != null)
                        {
                            Camera_Tracking[i].transform.position = new Vector3(Select_Guest[i].transform.position.x - 1.5f, Select_Guest[i].transform.position.y + 2.5f, Select_Guest[i].transform.position.z - 1.5f);
                            Camera_Tracking[i].transform.eulerAngles = new Vector3(45, 45, 0);
                        }
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Q)) { Camera_Mode = 3; }
                    else if (Input.GetKeyDown(KeyCode.E)) { Camera_Mode = 1; }

                    Base_Point[1].transform.eulerAngles = new Vector3(45, 135, 0);

                    for (int i = 0; i < 6; i++)
                    {
                        if (Select_Guest[i] != null)
                        {
                            Camera_Tracking[i].transform.position = new Vector3(Select_Guest[i].transform.position.x - 1.5f, Select_Guest[i].transform.position.y + 2.5f, Select_Guest[i].transform.position.z + 1.5f);
                            Camera_Tracking[i].transform.eulerAngles = new Vector3(45, 135, 0);
                        }
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.Q)) { Camera_Mode = 0; }
                    else if (Input.GetKeyDown(KeyCode.E)) { Camera_Mode = 2; }

                    Base_Point[1].transform.eulerAngles = new Vector3(45, 225, 0);

                    for (int i = 0; i < 6; i++)
                    {
                        if (Select_Guest[i] != null)
                        {
                            Camera_Tracking[i].transform.position = new Vector3(Select_Guest[i].transform.position.x + 1.5f, Select_Guest[i].transform.position.y + 2.5f, Select_Guest[i].transform.position.z + 1.5f);
                            Camera_Tracking[i].transform.eulerAngles = new Vector3(45, 225, 0);
                        }
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Base_Point[0].transform.Translate(Vector3.back * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        Base_Point[0].transform.Translate(Vector3.right * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Base_Point[0].transform.Translate(Vector3.forward * Camera_Speed * Time.deltaTime);
                        Base_Point[0].transform.Translate(Vector3.left * Camera_Speed * Time.deltaTime);
                    }
                    break;
            }
        }
    }
   
   public bool Check_Upstair(Vector3 Location)
    {
        if (Ground_LIst[(int)(Location.y * 2) +1][(int)Location.x][(int)Location.z].transform.childCount!=0)
        {
            return false; 
        }
        else
        {
            return true;
        }
      

    }
    public bool Check_Downstair(Vector3 Location)
    {
        if (Ground_LIst[(int)(Location.y * 2) - 1][(int)Location.x][(int)Location.z].transform.childCount != 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    public void Destroy_Ground(Vector3 Location)
    {
        if (Ground_LIst[(int)Location.y * 2][(int)Location.x][(int)Location.z].transform.childCount != 0)
        {
            Destroy(Ground_LIst[(int)Location.y * 2][(int)Location.x][(int)Location.z].transform.GetChild(0));
           
        }
        return;
    }
    void Park_State()
    {
        

    }
    public void Open_Rides_Select()
    {
        Ride_Select_Popup.SetActive(true);
    }

    public void Ground_dataset()
    {

    }
}
