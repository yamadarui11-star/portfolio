using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananacontroller : MonoBehaviour
{
    private void Start()
    {
        if (Datasave.Instance.savedata.bananaget)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
   
}
