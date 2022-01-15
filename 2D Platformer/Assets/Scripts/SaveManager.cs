using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SavaData/";
    public static string fileName = "MyData.txt";

    public static void Save(Gun so){
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }
    public static Gun Load(){
        string fullPath = Application.persistentDataPath + directory + fileName;
        Gun so = new Gun();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<Gun>(json);
        }
        else
        {
            Debug.Log("save file does not exist");
        }

        return so;
    }
}
