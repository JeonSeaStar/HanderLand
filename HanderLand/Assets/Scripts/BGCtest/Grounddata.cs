using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounddata : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int x_location, y_location, z_location;
    [SerializeField]
    private BuildingList BuildList;



    public int X_location
    {
        get { return x_location; }
        set { x_location = value; }
    }
    public int Y_location
    {
        get { return y_location; }
        set { y_location = value; }
    }
    public int Z_location
    {
        get { return z_location; }
        set { z_location = value; }
    }
    public Vector3 Location_data
    {
        get { return new Vector3(x_location, y_location, z_location); }
        set
        {
            x_location = (int)value.x;
            y_location = (int)(value.y);
            z_location = (int)value.z;
        }
    }
    [SerializeField]
    private int build_code = 0;

    public int Build_code
    {
        get { return build_code; }
        set
        {
            build_code = value;
            Buildind_change(build_code);
        }

    }
    public void Buildind_change(int buildcode)
    {
        if (this.transform.childCount != 0)
        {
            Destroy(this.gameObject.transform.GetChild(0));
        }
        //오브젝트 뽑을 떄 
        GameObject ground =Instantiate(BuildList.BuildingObject[buildcode],this.gameObject.transform);
      
    }

    [SerializeField]
    private int direction;
    //direction 0=>0   1=>90    2=>180   3=>270

    public void Save_Location_Data(int x, int y, int z)
    {
        this.x_location = x;
        this.y_location = y;
        this.z_location = z;
        this.build_code = 0;
        this.direction = 0;
    }

    public void Save_Location_Data(int x, int y, int z, int build_code)
    {
        this.x_location = x;
        this.y_location = y;
        this.z_location = z;
        this.build_code = build_code;
        this.direction = 0;

    }
    public void Save_Location_Data(int x, int y, int z, int build_code, int direction)
    {
        this.x_location = x;
        this.y_location = y;
        this.z_location = z;
        this.build_code = build_code;
        this.direction = direction;
    }
    public void Save_Location_Data(int direction)
    {
        this.direction = direction;
    }
 
    public void Change_Build(int BuildCode)
    {
        this.Build_code = BuildCode;
    }

    /// <summary>
    ///  direction 0=>0   1=>90    2=>180   3=>270
    /// </summary>
    /// <param name="Direction"></param>
    public void Direction_Change(int Direction)
    {
        this.direction = Direction;
        this.gameObject.transform.localRotation = Quaternion.AngleAxis(90 * direction, Vector3.up);
    }

    private void Start()
    {
        if (this.gameObject.transform.childCount == 0)
        {
            if (Y_location == 0)
            {
                Change_Build(1);
            }
        }
        this.gameObject.transform.localEulerAngles = new Vector3(0, direction * 90, 0);
    }
}
