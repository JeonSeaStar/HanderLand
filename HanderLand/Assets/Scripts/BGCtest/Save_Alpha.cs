using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class Save_Alpha 
{
    // Start is called before the first frame update
    
    public static void SaveData()
    {
        BinaryFormatter format = new BinaryFormatter();

        string path = Application.persistentDataPath + "/GroundData";
        FileStream stram = new FileStream(path, FileMode.Create);

        Save_Load data = new  Save_Load();
        format.Serialize(stram, data);
        stram.Close();

    }

    public static Save_Load LoadData()
    {
        string path = Application.persistentDataPath + "/GroundData";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           Save_Load data =  formatter.Deserialize(stream) as Save_Load;
            stream.Close();
            return data;
        }
        return null;
    }

}
