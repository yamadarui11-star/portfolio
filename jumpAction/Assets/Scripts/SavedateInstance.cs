using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class SavedateInstance : MonoBehaviour
{
    public static SavedateInstance instance;
    public Savedate savedate;
    string filePath;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            savedate = new Savedate();
             filePath = Application.persistentDataPath + "/savedate.json";
            Load();
            Debug.Log(filePath);
        }
        else Destroy(gameObject);

    }
    public void Save()
    {
        Debug.Log(savedate.interstitialGauge);
        string json = JsonUtility.ToJson(savedate);
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
            savedate = JsonUtility.FromJson<Savedate>(data);
        }
        else
        {
            InitSavedata();
            Save();
        }
    }

    public StageClearDate GetStageClearData(StageData.Type stage)
    {
        return savedate.stageClearDates.Find(n => n.stage == stage);//stageClearDatasの要素のstageClearDataのstageがstageの要素を返す
    }

    public void SaveStageClearData(StageData.Type stage,bool isclear,float clearTime,int clearStar)
    {
        StageClearDate stageClearDate=savedate.stageClearDates.Find(n => n.stage == stage);
        if (stageClearDate != null)//引数のステージのクリア情報が存在するとき
        {
            stageClearDate.stage = stage;//セーブデータのリストを書き換える
            stageClearDate.stageClear = isclear;
            if(stageClearDate.bestclearStar<clearStar) stageClearDate.bestclearStar = clearStar;
            if (clearTime < stageClearDate.bestclearTime) stageClearDate.bestclearTime = (float)System.Math.Ceiling(clearTime*100)/ 100f;
        }
        else
        {
            savedate.stageClearDates.Add(new StageClearDate(stage, isclear, (float)System.Math.Ceiling(clearTime * 100) / 100f, clearStar));
        }
        Save();
    }

    
    private void InitSavedata()
    {
        savedate.interstitialGauge = 0;
        savedate.goalCount = 0;
    }
}
