using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nabebanana : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Datasave.Instance.savedata.cooked)
        {

            if (Datasave.Instance.savedata.putbanana)
            {
                gameObject.SetActive(true);
            }
            else if (!Datasave.Instance.savedata.putbanana)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);

        }
    }
}
