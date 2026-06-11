using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife2clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Datasave.Instance.savedata.knife2clear)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
