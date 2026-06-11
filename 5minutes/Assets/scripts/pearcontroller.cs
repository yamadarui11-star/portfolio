using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pearcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Datasave.Instance.savedata.knife1clear&& Datasave.Instance.savedata.knife2clear)
        {
            if (Datasave.Instance.savedata.pearget)
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
