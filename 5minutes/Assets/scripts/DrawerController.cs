using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

   public void Enddraw()
    {
        
        gameDirector.PreventtouchpanelOff();
    }
   
}
