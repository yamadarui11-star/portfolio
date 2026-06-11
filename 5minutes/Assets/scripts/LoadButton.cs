using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Datasave.Instance.savedata.dataexist)
        {
            Debug.Log("savedate exsist and show Loadbutton");
            gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("savedate not exsist and hide Loadbutton");
            gameObject.SetActive(false);
        }
    }

}
