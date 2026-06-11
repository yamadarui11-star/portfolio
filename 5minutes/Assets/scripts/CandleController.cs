using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    float candletime=0;
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        if (Datasave.Instance.savedata.clearcandle)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);

        }
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (gameDirector.candlefireison)
        {
            candletime += Time.deltaTime;
            if (candletime >= 60)
            {
                gameObject.GetComponent<DetectController>().enabled = false;
                Datasave.Instance.savedata.clearcandle = true;
                gameObject.SetActive(false);
            }
        }
    }
}
