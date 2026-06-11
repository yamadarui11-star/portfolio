using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer1keyController : MonoBehaviour
{
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        gameObject.SetActive(false);
    }

    public void Endunlock()
    {
        gameDirector.PreventtouchpanelOff();
        gameObject.SetActive(false);
    }
 
}
