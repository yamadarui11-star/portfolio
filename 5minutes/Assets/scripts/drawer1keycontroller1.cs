using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer1keycontroller1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Datasave.Instance.savedata.cooked)
        {
            if (Datasave.Instance.savedata.drawer1keyget)
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
