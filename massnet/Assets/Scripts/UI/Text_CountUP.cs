using TMPro;
using UnityEngine;

public class Text_CountUP : MonoBehaviour
{
    int toNum;
    int num=0;
    public bool end = false;
    [SerializeField] TextMeshProUGUI Text_countUP;
    private void OnEnable()
    {
        toNum = Director.instance.massScore;
    }
    public void End()
    {
        Text_countUP.text = "+" + toNum.ToString();
        end = true;
    }

    private void FixedUpdate()
    {
        if (!end)
        {
            if (num <= toNum)
            {
                Text_countUP.text = "+" + num.ToString(); 
                SoundManager.instance.PlaySE(SoundManager.audioClips_type.pi);
            }
            else End();
            
        }
        num++;
    }
}
