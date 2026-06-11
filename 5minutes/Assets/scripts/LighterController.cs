using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterController : MonoBehaviour
{
    

    SoundManager soundManager;
    GameDirector gameDirector;
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    public void LighterSE()
    {
        soundManager.Lighter();
    }
    public void Candlefire()
    {
        if (Datasave.Instance.savedata.airconison)
        {
            
        }else if(!Datasave.Instance.savedata.airconison)
        {
            gameDirector.candlefireison = true;
            gameDirector.candlefire.SetActive(true);
        }
    }
    public void Endlighter()
    {
        gameDirector.PreventtouchpanelOff();
        gameObject.SetActive(false);
    }
}
