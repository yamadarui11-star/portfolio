using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nabecollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (Datasave.Instance.savedata.cooked)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled=true;
        }
    }

}
