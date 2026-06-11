using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slidebuttoncontroller : MonoBehaviour
{
    GameDirector gameDirector;
   
    
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
   
       
    }
    
   public void Endswitch()
    {
        gameDirector.PreventtouchpanelOff();
    }
}
