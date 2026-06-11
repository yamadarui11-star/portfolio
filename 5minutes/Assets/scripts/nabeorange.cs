using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nabeorange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Datasave.Instance.savedata.cooked)
        {
            if (Datasave.Instance.savedata.putorange)
            {
                gameObject.SetActive(true);
            }
            else if (!Datasave.Instance.savedata.putorange)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
       
    }

}
