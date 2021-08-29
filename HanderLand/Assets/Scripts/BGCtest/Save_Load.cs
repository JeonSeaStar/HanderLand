using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;



[System.Serializable]
public class Save_Load :MonoBehaviour
{
    public GameManager grounddata;
    public int[,,] groundcode;
    public int[,,] direction;
    public Save_Load()
    {
        int y = 0;
      //Load(grounddata.Ground_LIst, grounddata.x, y = grounddata.x > grounddata.z ? grounddata.x : grounddata.z, grounddata.z);
        Save(grounddata.Ground_LIst, grounddata.x, y = grounddata.x > grounddata.z ? grounddata.x : grounddata.z, grounddata.z);
        
    }
    public void Save(List<List<List<GameObject>>> Data,int x,int y,int z)
    {
        Debug.Log("Check point1");
        groundcode = new int[y, x, z];
        direction = new int[y, x, z];
        for (int j =0; j<y;j++)
        {
            for(int i=0; i<x;i++)
            {
                for(int k=0;k<z;k++)
                {
                    if(Data[j][i][k].transform.childCount>=1)
                    {
                        groundcode[j, i ,k] = Data[j][i][k].GetComponent<Grounddata>().Build_code;
                        Debug.Log("SAVE!!"+j+"   "+i+"    "+k);
                        direction[j, i, k] = Data[j][i][k].GetComponent<Grounddata>().Get_Direction();
                    }
                  
     
                }
            }

        }


    }
    public void Load(List<List<List<GameObject>>> Data, int x, int y, int z)
    {
        
        groundcode = new int[y, x, z];
        direction = new int[y, x, z];
        for (int j = 0; j < y; j++)
        {
            for (int i = 0; i < x; i++)
            {
                for (int k = 0; k < z; k++)
                {
                    if (Data[j][i][k].transform.childCount >= 1)
                    {
                         Data[j][i][k].GetComponent<Grounddata>().Build_code= groundcode[j, i, k] ;
                        Debug.Log("SAVE!!" + j + "   " + i + "    " + k);
                        Data[j][i][k].GetComponent<Grounddata>().Direction_Change(direction[j, i, k]); 
                    }


                }
            }

        }


    }
    IEnumerator Save_Data()
    {
        yield return new WaitForSeconds(5.0f);
        int y=0;
        Save(grounddata.Ground_LIst,grounddata.x,  y =  grounddata.x > grounddata.z ? grounddata.x :grounddata.z, grounddata.z);
        Debug.Log("test3");
        Save_Alpha.SaveData();
        StartCoroutine(Save_Data());

    }
    private void Start()
    {
        Debug.Log("test");
        int y = 0;
        Save(grounddata.Ground_LIst, grounddata.x, y = grounddata.x > grounddata.z ? grounddata.x : grounddata.z, grounddata.z); 
        Debug.Log("test2");
        Save_Alpha.LoadData();
        StartCoroutine(Save_Data());
    }

}

