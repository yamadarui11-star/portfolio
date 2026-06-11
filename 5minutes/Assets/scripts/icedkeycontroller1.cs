using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icedkeycontroller1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Datasave.Instance.savedata.clearicedkey)
        {
            gameObject.SetActive(true);

            if (Datasave.Instance.savedata.icedkeyget)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
