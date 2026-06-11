using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatercupinkeyController : MonoBehaviour
{

    GameDirector gameDirector;
    GameObject waterkey;

    private void Awake()
    {
        waterkey =GameObject.Find("waterkey");
    }
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        
    }

    public void Endpourwaterinkeyshape()
    {
        gameDirector.watershapeisfull = true;
        waterkey.SetActive(true);
        
        gameDirector.Updateitem(Data.tags.cup);
        gameDirector.PreventtouchpanelOff();
        gameObject.SetActive(false);
    }

    
}
