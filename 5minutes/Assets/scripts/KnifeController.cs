using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    SoundManager soundManager;
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    public void knifeSE()
    {
        soundManager.Knife();
    }
    public void Endknifepush()
    {

        gameDirector.PreventtouchpanelOff();
        gameDirector.KnifeClear();
    }
}
