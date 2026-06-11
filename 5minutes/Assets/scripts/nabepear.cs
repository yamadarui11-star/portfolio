using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nabepear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Datasave.Instance.savedata.cooked)
        {

            if (Datasave.Instance.savedata.putpear)
            {
                gameObject.SetActive(true);
            }
            else if (!Datasave.Instance.savedata.putpear)
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
