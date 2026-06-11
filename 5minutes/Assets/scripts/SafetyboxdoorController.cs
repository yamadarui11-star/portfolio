using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyboxdoorController : MonoBehaviour
{
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    public void Endopensafetybox()
    {
        gameDirector.PreventtouchpanelOff();
    }
}
