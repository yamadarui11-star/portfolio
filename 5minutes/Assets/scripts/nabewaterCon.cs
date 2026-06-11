using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nabewaterCon : MonoBehaviour
{
    void Start()
    {
            if (Datasave.Instance.savedata.fullwaterinnabe)
            {
                gameObject.SetActive(true);

            }
            else if (!Datasave.Instance.savedata.fullwaterinnabe)
            {
                gameObject.SetActive(false);
            }
        }
    }

