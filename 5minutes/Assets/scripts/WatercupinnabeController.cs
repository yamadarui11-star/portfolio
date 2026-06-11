using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatercupinnabeController : MonoBehaviour
{
    GameDirector gameDirector;
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    public void Endaddwaterinnabe()
    {
        Datasave.Instance.savedata.fullwaterinnabe = true;
        gameDirector.PreventtouchpanelOff();
        gameObject.SetActive(false);
    }
}
