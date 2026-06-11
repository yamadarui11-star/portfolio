using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife2controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (Datasave.Instance.savedata.knife2get)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

}
