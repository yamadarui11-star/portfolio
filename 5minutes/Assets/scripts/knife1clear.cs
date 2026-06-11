using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife1clear : MonoBehaviour
{
    void Start()
    {
        if (Datasave.Instance.savedata.knife1clear)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
