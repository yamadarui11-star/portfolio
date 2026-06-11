using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safetyboxkeycontroller1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (Datasave.Instance.savedata.safetyboxkeyget)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

}
