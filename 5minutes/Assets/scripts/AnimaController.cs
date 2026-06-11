using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaController : MonoBehaviour
{
    Animator cupAnima;
    Animator watercupAnima;
    Animator remoconAnima;
    Animator orangeAnima;
    Animator knife1Anima;
    Animator knife2Anima;
    Animator refrigeratorAnima;
    Animator pourwaterinkeyshapeAnima;
    Animator icedkeyAnima;
    Animator door2Anima;
    Animator lighteranima;
    Animator safetyboxunlock;
    Animator safetyboxopenAnima;
    Animator opentrashcanAnima;
    Animator risewater;
    Animator addwaterinnabe;
    Animator drawer1unlockAnima;

    GameObject cup;
    GameObject watercup;
    GameObject remocon;
    GameObject orange;
    GameObject watercup2;


    GameObject knife1foranima;
    GameObject knife2foranima;
    GameDirector gameDirector;

    SoundManager soundManager;


    public DataList dataList;

    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        drawer1unlockAnima = GameObject.Find("drawer1keyanima").GetComponent<Animator>();
        addwaterinnabe = GameObject.Find("addwaterinnabeanima").GetComponent<Animator>();
        risewater = GameObject.Find("nabe").GetComponent<Animator>();
        safetyboxopenAnima = GameObject.Find("safetyboxdooranima").GetComponent<Animator>();
        safetyboxunlock =GameObject.Find("safetyboxkeyanima").GetComponent<Animator>();
        lighteranima = GameObject.Find("lighteranima").GetComponent<Animator>();
        icedkeyAnima = GameObject.Find("icedkeyanima").GetComponent<Animator>();
        watercup2 = GameObject.Find("watercup2");
        pourwaterinkeyshapeAnima = watercup2.GetComponent<Animator>();
        cup = GameObject.Find("Mug");
        watercup = GameObject.Find("watercup");
        remocon = GameObject.Find("remotocontroller");
        orange = GameObject.Find("orange");
        knife1foranima = GameObject.Find("knife1foranima");
        knife1Anima = knife1foranima.GetComponent<Animator>();
        orangeAnima = orange.GetComponent<Animator>();
        knife2foranima = GameObject.Find("knife2foranima");
        knife2Anima = knife2foranima.GetComponent<Animator>();
        refrigeratorAnima = GameObject.Find("refrigeratorobj").GetComponent<Animator>();
        door2Anima = GameObject.Find("door2").GetComponent<Animator>();
        opentrashcanAnima = GameObject.Find("trashcancover").GetComponent<Animator>();
    }
    void Start()

    {
        watercup2.SetActive(false);
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        remoconAnima = remocon.GetComponent<Animator>();
        cupAnima = cup.GetComponent<Animator>();
        watercupAnima = watercup.GetComponent<Animator>();

        knife1foranima.SetActive(false);
        knife2foranima.SetActive(false);

    }




    public void AddwaterinCup()
    {
        
        gameDirector.PreventtouchpanelOn();//画面を触らせない
        cup.SetActive(true);
        cupAnima.SetBool("addwaterincupBool", true);
        
    }

    public void Pourwater()
    {
        
        gameDirector.PreventtouchpanelOn();
        watercup.SetActive(true);
        watercupAnima.SetBool("pourwaterBool", true);

    }

    public void Growflower(Data.tags tag)
    {
        GameObject.Find(dataList.Returndata(tag).objname).GetComponent<Animator>().SetBool("growflowerBool", true); //potの種類（名前:flower1,2,3,4）を取得、そのポットのgrowアニメーション実行
    }
    
    public void Remocon()
    {
       
        gameDirector.PreventtouchpanelOn();
        remocon.SetActive(true);
        remoconAnima.SetBool("remocononoffBool", true);
    }

    public void Orangegrow()
    {
        orangeAnima.SetBool("groworangeBool", true);
    }

    
    public void Draweranima(Data.tags tag)
    {
        Animator anima;
        anima = GameObject.Find(dataList.Returndata(tag).objname).GetComponent<Animator>();
        gameDirector.PreventtouchpanelOn();
        if (anima.GetBool("drawBool"))//引き出しを開けている状態のとき
        {
            soundManager.Drawer();
            if(tag == Data.tags.drawer1) gameDirector.drawer1isopen = false;
            if (tag == Data.tags.drawer3) gameDirector.drawer3isopen = false;//drawer3の時draw3iscloseにする
            if (tag == Data.tags.drawer4) gameDirector.drawer4isopen = false;//draw4の時draw4iscloseにする
            anima.SetBool("drawBool", false);//閉じる
        }
        else
        {
            soundManager.Drawer();
            anima.SetBool("drawBool", true);//開ける
            if (tag == Data.tags.drawer1) gameDirector.drawer1isopen = true;//drawer3の時draw3isopenにする
            if (tag == Data.tags.drawer3) gameDirector.drawer3isopen= true;//drawer3の時draw3isopenにする
            if (tag == Data.tags.drawer4) gameDirector.drawer4isopen = true;//draw4の時draw4isopenにする
        }

       
        
    }

    public void Drawer1unlock()
    {
        gameDirector.PreventtouchpanelOn();
        drawer1unlockAnima.SetBool("drawer1unlockBool",true);
    }
    
    public void SlidebuttonOn(Data.tags tag)
    {
        soundManager.Slidebutton();
        gameDirector.PreventtouchpanelOn();
        GameObject.Find(dataList.Returndata(tag).objname).GetComponent<Animator>().SetBool("SlideOn", true);
    }
    public void SlidebuttonOff(Data.tags tag)
    {
        soundManager.Slidebutton();
        gameDirector.PreventtouchpanelOn();
        GameObject.Find(dataList.Returndata(tag).objname).GetComponent<Animator>().SetBool("SlideOn", false);
    }

    public void Knife1Anima()
    {
        gameDirector.PreventtouchpanelOn();
        knife1foranima.SetActive(true);
        knife1Anima.SetBool("knife1Bool", true);
    }
    public void Knife2Anima()
    {

        gameDirector.PreventtouchpanelOn();
        knife2foranima.SetActive(true);
        knife2Anima.SetBool("knife2Bool", true);
    }

    public void DoorOpen(Data.tags tag)
    { 
        if (tag == Data.tags.refrigerator)
        {
       
            if (refrigeratorAnima.GetBool("dooropenBool"))//空いているとき
     
            {
                gameDirector.refrigeratordoorisopen = false;
                gameDirector.PreventtouchpanelOn();
                refrigeratorAnima.SetBool("dooropenBool", false);//閉める
                soundManager.Closefridge();
            }
       
            else
      
            {
                gameDirector.refrigeratordoorisopen = true;
                gameDirector.PreventtouchpanelOn();
                refrigeratorAnima.SetBool("dooropenBool", true);
                soundManager.Openfridge();
            }
       
            
        }
        
    }

    public void Pourwaterinkeyshape()
    {
        if (gameDirector.refrigeratordoorisopen)
        {
         
            pourwaterinkeyshapeAnima.SetBool("pourwaterinkeyshape", true);
            gameDirector.PreventtouchpanelOn();

        }
    }
    public void Unlockdoor2()
    {
        icedkeyAnima.SetBool("door2open", true);
        gameDirector.PreventtouchpanelOn();
    }
    public void Opendoor2()
    {
        

        if (door2Anima.GetBool("door2openBool"))//空いているとき

        {
            gameDirector.door2isope = false;
            gameDirector.PreventtouchpanelOn();
            door2Anima.SetBool("door2openBool", false);//閉める

        }

        else

        {
            gameDirector.door2isope = true;
            gameDirector.PreventtouchpanelOn();
            door2Anima.SetBool("door2openBool", true);
        }
    }
    public void Lighter()
    {
        gameDirector.PreventtouchpanelOn();
        lighteranima.SetBool("lighterBool", true);
        
    }
    public void Safetyboxunlock()
    {
        
        gameDirector.PreventtouchpanelOn();
        safetyboxunlock.SetBool("safetyboxunlockBool", true);
    }

    public void Safetyboxopen()
    {
        gameDirector.PreventtouchpanelOn();
        if (gameDirector.safetyboxisopen)
        {
            gameDirector.safetyboxisopen = false;
            safetyboxopenAnima.SetBool("safetyboxdooropenBool", false);
        }
        else if (!gameDirector.safetyboxisopen)
        {
            gameDirector.safetyboxisopen = true;
            safetyboxopenAnima.SetBool("safetyboxdooropenBool", true);
        }
        
    }

    public void Opentrashcan()
    {
        gameDirector.PreventtouchpanelOn();
        opentrashcanAnima.SetBool("trashcanopenBool", true);
    }
    public void Addwaterinnabe()
    {
        gameDirector.PreventtouchpanelOn();
        risewater.SetBool("risewaterBool", true);
        addwaterinnabe.SetBool("addwaterinnabeBool", true);
    }
}
