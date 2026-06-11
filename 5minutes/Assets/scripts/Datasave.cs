using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Scripting;

public class Datasave
{
    //singleton
    private static Datasave instance = new Datasave();
    public static Datasave Instance=>instance;

    private Datasave() {Load(); }//起動時セーブデータのロード

    public string Path => Application.persistentDataPath + "/data.json";
    
    public Savedata savedata { get; private set; }

    public void Save()
    {
        string jsonData = JsonUtility.ToJson(savedata);

        StreamWriter writer = new StreamWriter(Path, false);
        writer.WriteLine(jsonData);
        writer.Flush();
        writer.Close();
       
    }

    public void Load()
    {
        Debug.Log(Path);
        if (!File.Exists(Path))
        {
            savedata = new Savedata();
            Save();
            Debug.Log("file not found");
            return;
        }
        
            StreamReader reader = new StreamReader(Path);
            string jsonData = reader.ReadToEnd();
            savedata = JsonUtility.FromJson<Savedata>(jsonData);
            reader.Close();
        
        
    }
    public void Initialization()
    {
        Debug.Log("savedate has init");
        savedata = new Savedata();
        Debug.Log("save date");
        Save();
    }
}
