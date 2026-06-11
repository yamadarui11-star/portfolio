using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcedkeyController : MonoBehaviour
{
    SoundManager soundManager;
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    public void UnlockSE()
    {
        soundManager.Unlock();
    }
    public void Endunlockdoor2()
    {
        gameDirector.PreventtouchpanelOff();
        gameObject.SetActive(false);
    }
}
