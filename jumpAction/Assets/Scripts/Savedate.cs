
using System.Collections.Generic;
using System;
[Serializable]
public class Savedate
{

    public List<StageClearDate> stageClearDates = new List<StageClearDate>();
    public int interstitialGauge;
    public int goalCount;
}
[Serializable]
public class StageClearDate
{
    public StageData.Type stage;
    public float bestclearTime;
    public bool stageClear;
    public int bestclearStar;
    public StageClearDate(StageData.Type stage, bool stageClear, float clearTime,  int clearStar)
    {
        this.stageClear = stageClear;
        bestclearTime = clearTime;
        bestclearStar = clearStar;
        this.stage = stage;
    }
}
