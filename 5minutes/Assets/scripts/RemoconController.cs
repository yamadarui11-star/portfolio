using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoconController : MonoBehaviour
{
    SoundManager soundManager;
    GameDirector gameDirector;
    TextMeshPro remocontext;
    
    private void Awake()
    {

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        remocontext = GameObject.Find("remocontext").GetComponent<TextMeshPro>();
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    private void Start()
    {

        if (Datasave.Instance.savedata.remoconget)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    public void SwitchSE()
    {
        soundManager.Remocon();
    }
    public void Switchonoff()
    {
        if (Datasave.Instance.savedata.airconison) //switchONÇÃèÍçá
        {
            Datasave.Instance.savedata.airconison = false;
            gameDirector.Updateitem(Data.tags.remotocontrolleroff);
            remocontext.text = "OFF";

        }
        else
        {
            Datasave.Instance.savedata.airconison = true;
            gameDirector.Updateitem(Data.tags.remotocontrolleron);
            remocontext.text = "ON";
        }
    }

    public void SetactiveOff()
    {
        gameDirector.PreventtouchpanelOff();//âÊñ ÇêGÇÍÇÈÇÊÇ§Ç…Ç∑ÇÈ
        gameObject.SetActive(false);
        
    }
}
