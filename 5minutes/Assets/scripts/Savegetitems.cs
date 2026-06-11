using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savegetitems : MonoBehaviour
{
    
    public static void SaveItem(Data.tags tag)
    {

        Debug.Log("save item" + tag);
        if (tag == Data.tags.cup)
        {
            Datasave.Instance.savedata.mugget = true;
        }
        else if (tag == Data.tags.smallflower)
        {
            Datasave.Instance.savedata.smallflowerget = true;
        }
        else if (tag == Data.tags.remotocontrolleron)
        {
            Datasave.Instance.savedata.remoconget = true;
        }
        else if (tag == Data.tags.pear)
        {
            Datasave.Instance.savedata.pearget = true;
        }
        else if (tag == Data.tags.banana)
        {
            Datasave.Instance.savedata.bananaget = true;
        }
        else if (tag == Data.tags.orange)
        {
            Datasave.Instance.savedata.orangeget = true;
        }
        else if (tag == Data.tags.lighter)
        {
            Datasave.Instance.savedata.lighterget = true;
        }
        else if (tag == Data.tags.knife1)
        {
            Datasave.Instance.savedata.knife1get = true;
        }
        else if (tag == Data.tags.knife2)
        {
            Datasave.Instance.savedata.knife2get = true;
        }
        else if (tag == Data.tags.drawer1key)
        {
            Datasave.Instance.savedata.drawer1keyget = true;
        }
        else if (tag == Data.tags.icedkey)
        {
            Datasave.Instance.savedata.icedkeyget = true;
        }

        else if (tag == Data.tags.safetyboxkey)
        {
            Datasave.Instance.savedata.safetyboxkeyget = true;
        }
        else
        {
            Debug.Log("can not save item");
        }
        
    }
}
