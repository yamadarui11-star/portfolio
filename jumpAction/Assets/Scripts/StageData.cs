
using UnityEngine;
[CreateAssetMenu]
[System.Serializable]
public class StageData : ScriptableObject
{
    public enum Type
    {
        stage1,
        stage2,
        stage3,
        stage4,
        stage5,
        stage6,
        stage7,
        stage8,
        stage9,
        stage10,
        stage11,
        stage12,
        stage13,
        stage14,
        stage15,
    }
    public Type type;
    public float time_star3;
    public float time_star2;
    public float time_star1;
    public int stageNum;
}

