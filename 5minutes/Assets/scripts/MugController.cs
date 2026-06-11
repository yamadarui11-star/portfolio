using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugController : MonoBehaviour
{
    SoundManager soundManager;
    Data.tags watercup;
    GameDirector gameDirector;

    
    void Start()
    {

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        watercup = Data.tags.watercup;
        gameDirector = GameObject.Find("GameDirector"). GetComponent<GameDirector>();

        if (Datasave.Instance.savedata.mugget)
        {
            Debug.Log(Datasave.Instance.savedata.mugget+"mug and setactive false this item");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(Datasave.Instance.savedata.mugget + "mug and setactive true this item");
            gameObject.SetActive(true);
        }
    }

    public void PourwaterSE()
    {
        soundManager.Pourwater();
    }
    public void EndtoAddWater()
    {
        gameDirector.Updateitem(watercup);
        gameObject.SetActive(false);
        gameDirector.PreventtouchpanelOff();//âÊñ ÇêGÇÍÇÈÇÊÇ§Ç…Ç∑ÇÈ
    }
  
}
