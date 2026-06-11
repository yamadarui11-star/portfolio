using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightercontroller1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (Datasave.Instance.savedata.lighterget)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

}
