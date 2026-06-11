using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public SoundManager soundManager;
    public GameObject menupanel;
    public GameObject resetpanel;
    public GameObject Admob;
    
    public GameObject selectnewgamepanel;

    public void Showmenupanel()
    {

        soundManager.Touchmenu();
        menupanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        Time.timeScale = 1;
        soundManager.Touchmenu();
        resetpanel.SetActive(true);
    }
    public void Hidemenupanel()
    {
        soundManager.Cancel();
        menupanel.SetActive(false);
        Time.timeScale = 1;

        Datasave.Instance.savedata.menubuttonclick++;
        if (Datasave.Instance.savedata.menubuttonclick % 3 == 1)
        {
            Admob.GetComponent<Admobinterstitial>().ShowAd();
        }
    }
    public void Toplayscene()
    {
        Admob.GetComponent<Admobinterstitial>().ShowAdandToplayscene();
    }
    public void ToNewplayscene()
    {
        //Datasave.Instance.Initialization();
        Admob.GetComponent<Admobinterstitial>().ShowAdandToNEWplayscene();
        Datasave.Instance.savedata.dataexist = true;
        Debug.Log("savedateexsist = true");
        
        
    }

    public void Resetpanelno()
    {
        soundManager.Cancel();
        resetpanel.SetActive(false);
    }
    public void Totitlescene()
    {
        fadeinout.fadeinoutinstance.Resetgame("Titlescene");
    }

    public void ShowselectNewgamepanel()
    {

        Debug.Log("savedate:" + Datasave.Instance.savedata);
        Debug.Log("touch newgame button");
        if (Datasave.Instance.savedata.dataexist)
        {
            Debug.Log("savedate is exist");
            Debug.Log("show selectnewgame panel");

            selectnewgamepanel.SetActive(true);
            Admob.GetComponent<Admobinterstitial>().ShowAd();
        }
        else
        {
            Debug.Log("savedate not exist");
            Debug.Log("Goto newplayscene");
            //ToNewplayscene();
            Admob.GetComponent<Admobinterstitial>().ShowAdandToNEWplayscene();
        }
    }

    public void CloseselectNewgamepanel()
    {
        selectnewgamepanel.SetActive(false);
    }
}
