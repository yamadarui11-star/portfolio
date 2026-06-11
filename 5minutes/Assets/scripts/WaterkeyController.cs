using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterkeyController : MonoBehaviour
{
    float watertoicetime=0;
    
   
    GameObject icedkey;
    GameDirector gameDirector;
    // Start is called before the first frame update
    private void Awake()
    {
        icedkey = GameObject.Find("icedkey");
    }
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!gameDirector.refrigeratordoorisopen)
        {
            watertoicetime += Time.deltaTime;
            if (watertoicetime >= 10)
            {
                if (!Datasave.Instance.savedata.clearicedkey)
                {
                    Datasave.Instance.savedata.clearicedkey = true;
                    icedkey.SetActive(true);
                    gameObject.SetActive(false);
                }
                
            }
        }
    }
}
