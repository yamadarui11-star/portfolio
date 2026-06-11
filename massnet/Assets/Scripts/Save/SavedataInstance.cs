using System.IO;
using UnityEngine;

public class SavedataInstance : MonoBehaviour
{
    public static SavedataInstance instance;
    [System.NonSerialized]
    public Savedata savedata;
    string filePath;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/savedata.json";
        savedata = new Savedata();
        Load();
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(savedata);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }
    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            savedata = JsonUtility.FromJson<Savedata>(data);
        }
        else
        {
            InitSavedata();
            Save();
        }
    }
    private void InitSavedata()
    {
        savedata.playerSize_Level = 1;
        savedata.ownMassScore = 0;
        savedata.playerSpeed_Level = 1;
        savedata.selectedStage = 1;
        savedata.maxStage = 1;
        savedata.boostTime = 0;
        savedata.backToTitleNum = 0;
        savedata.playNum = 0;
    }
}
