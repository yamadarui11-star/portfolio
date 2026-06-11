using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titlebutton : MonoBehaviour
{
    int num;
    GameObject selectnewgamepanel;
    private void Start()
    {
        selectnewgamepanel = GameObject.Find("Selectnewgamepanel");
        selectnewgamepanel.SetActive(false);
    }
    public void Toplayscene()
    {

        fadeinout.fadeinoutinstance.Resetgame("PlayScene");
    }
    public void ShowselectNewgamepanel()
    {
        if (Datasave.Instance.savedata.dataexist)
        {
            selectnewgamepanel.SetActive(true);
        }
        else
        {
            ToNewplayscene();
        }
    }
    public void CloseselectNewgamepanel()
    {
        selectnewgamepanel.SetActive(false);
    }
    public void ToNewplayscene()
    {
        Datasave.Instance.Initialization();
        Datasave.Instance.savedata.dataexist = true;
        fadeinout.fadeinoutinstance.Resetgame("PlayScene");
    }

    public void AdClosed()
    {
        switch (num)
        {
            case 1:
                ToNewplayscene();
                break;

            case 2:
                Toplayscene();
                break;

        }
    }
    public void TonewpleysceneAfteradclose()
    {
        num = 1;
    }
    public void TopleysceneAfteradclose()
    {
        num = 2;
    }
}
