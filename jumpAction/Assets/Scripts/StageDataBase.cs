using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageDataBase : ScriptableObject
{
    public List<StageData> stageDatas = new List<StageData>();

    public StageData GetStageData(StageData.Type stage)
    {
        return stageDatas.Find(n => n.type == stage);
    }
}
