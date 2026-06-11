using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (Datasave.Instance.savedata.orangeget)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
