using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower5controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Datasave.Instance.savedata.existflower)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);     
        }
    }

}
