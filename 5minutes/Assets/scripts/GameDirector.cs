using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    TextMeshProUGUI itemnametext;
    TextMeshPro timetext;
    TextMeshPro keypadpaneltext;
    TextMeshPro trashbutton1text;
    int trashbutton1num = 0;
    TextMeshPro trashbutton2text;
    int trashbutton2num = 0;
    bool timestop=false;
    bool slidebutton1 = false;
    bool slidebutton2 = false;
    bool slidebutton3= false;
    bool slidebutton4 = false;
    public bool cleartrashbutton = false;
    public bool drawer1isopen = false;
    public bool drawer2isopen = false;
    public bool drawer3isopen=false;
    public bool drawer4isopen = false;
    public bool safetyboxisopen = false;
    public bool candlefireison = false;
    public bool door2isope = false;
    public bool watershapeisfull = false;
    public bool refrigeratordoorisopen = false;
    public bool cleardrawer1 = false;
    public bool cleardrawer3 = false;
    public bool cleardrawer4 = false;
    bool stopper = false;
    int min;
    int sec;
    float cooktime = 0;
    int keycount = 0;

    BoxCollider detect18collider;
    BoxCollider detect20collider;
    BoxCollider safetyboxcollider;
    BoxCollider detect17collider;
    BoxCollider drawer1collider;
    BoxCollider nabecollider;
    public GameObject Admob;
    public GameObject buttoncon;
    public GameObject gameclearpanel;
    public GameObject backtotitlebutton;
    public GameObject RewardAd;
    Image gameclearpanelimage;
    GameObject drawer1keyanima;
    GameObject orangeinnabe;
    GameObject pearinnabe;
    GameObject bananainnabe;
    GameObject drawer1key;
    GameObject lighteranima;
    GameObject backbutton;
    GameObject rightbutton;
    GameObject leftbutton;
    GameObject mainCam;
    GameObject pear;
    GameObject slotpanel1;
    GameObject slotpanel2;
    GameObject showitempanel;
    GameObject preventtouchpanel;
    GameObject flower5;
    GameObject watercup2;
    public GameObject[] slotsFrame;
    GameObject waterkey;
    GameObject icedkeyanima;
    public GameObject candlefire;
    GameObject safetyboxkeyanima;
    GameObject addwaterinnabeanima;
    CameraController camcon;
    public Image[] slotsImage = new Image[8];
    public Sprite[] foodImages1 = new Sprite[4];
    int foodimage1num = 0;
    public Sprite[] foodImages2 = new Sprite[4];
    int foodimage2num = 0;
    public Sprite[] foodImages3 = new Sprite[4];
    int foodimage3num = 0;
    public Sprite[] foodImages4 = new Sprite[4];
    int foodimage4num = 0;
    SpriteRenderer foodimage1;
    SpriteRenderer foodimage2;
    SpriteRenderer foodimage3;
    SpriteRenderer foodimage4;
    SoundManager soundManager;
    Image showitemimage;

    GameObject[] detectTagobjects;

    Stack<Data.tags> stackPreTags = new Stack<Data.tags>();
    Stack<Data.tags> stackTags = new Stack<Data.tags>();

    public DataList dataList;

    AnimaController animaController;

    private void Awake()
    {
        detect18collider = GameObject.Find("detect18").GetComponent<BoxCollider>();
        detect20collider = GameObject.Find("detect20").GetComponent<BoxCollider>();
        safetyboxcollider = GameObject.Find("safetybox").GetComponent<BoxCollider>();
        detect17collider = GameObject.Find("detect17").GetComponent<BoxCollider>();
        drawer1collider = GameObject.Find("drawer1").GetComponent<BoxCollider>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        itemnametext = GameObject.Find("itemtext").GetComponent<TextMeshProUGUI>();
        nabecollider = GameObject.Find("nabe").GetComponent<BoxCollider>();
        drawer1keyanima = GameObject.Find("drawer1keyanima");
        orangeinnabe = GameObject.Find("orangeinnabe");
        pearinnabe = GameObject.Find("pearinnabe");
        bananainnabe= GameObject.Find("bananainnabe");
        addwaterinnabeanima = GameObject.Find("addwaterinnabeanima");
        drawer1key = GameObject.Find("drawer1key");
        pear = GameObject.Find("pear");
        safetyboxkeyanima = GameObject.Find("safetyboxkeyanima");
        lighteranima = GameObject.Find("lighteranima");
        icedkeyanima = GameObject.Find("icedkeyanima");
        watercup2 = GameObject.Find("watercup2");
        timetext = GameObject.Find("timetext").GetComponent<TextMeshPro>();
        detectTagobjects = GameObject.FindGameObjectsWithTag("detects");
        mainCam = GameObject.Find("Main Camera");
        backbutton = GameObject.Find("BackButton");
        rightbutton = GameObject.Find("RightButton");
        leftbutton = GameObject.Find("LeftButton");
        keypadpaneltext = GameObject.Find("keypadpaneltext").GetComponent<TextMeshPro>();
        camcon = mainCam.GetComponent<CameraController>();
        candlefire = GameObject.Find("candlefire");
        slotpanel1 = GameObject.Find("slotpanel1");
        slotpanel2 = GameObject.Find("slotpanel2");
        showitempanel = GameObject.Find("showitempanel");
        showitemimage = GameObject.Find("showitemimage").GetComponent<Image>();
        animaController = GameObject.Find("AnimaController").GetComponent<AnimaController>();
        preventtouchpanel = GameObject.Find("preventtouchpanel");
        flower5 = GameObject.Find("flower5");
        foodimage1 = GameObject.Find("foodimage1").GetComponent<SpriteRenderer>();
        foodimage2 = GameObject.Find("foodimage2").GetComponent<SpriteRenderer>();
        foodimage3 = GameObject.Find("foodimage3").GetComponent<SpriteRenderer>();
        foodimage4 = GameObject.Find("foodimage4").GetComponent<SpriteRenderer>();
        waterkey = GameObject.Find("waterkey");
        trashbutton1text = GameObject.Find("trashbuttontext1").GetComponent<TextMeshPro>(); 
        trashbutton2text = GameObject.Find("trashbuttontext2").GetComponent<TextMeshPro>();
        gameclearpanelimage = gameclearpanel.GetComponent<Image>();
    }

    void Start()
    {
        gameclearpanel.SetActive(false);
        backtotitlebutton.SetActive(false);
        drawer1keyanima.SetActive(false);
        addwaterinnabeanima.SetActive(false);
        safetyboxkeyanima.SetActive(false);
        lighteranima.SetActive(false);
        candlefire.SetActive(false);
        icedkeyanima.SetActive(false);
        stackTags.Push(Data.tags.first);
        backbutton.SetActive(false);
        slotpanel2.SetActive(false);
        showitempanel.SetActive(false);
        preventtouchpanel.SetActive(false);
        AllTagsSetactive(slotsFrame, false);//�X���b�g�I���t���[�����A�N�e�B�u��
        waterkey.SetActive(false);
        watercup2.SetActive(false);
        if (Datasave.Instance.savedata.drawer1isunlock)
        {
            detect17collider.enabled = false;
        }
        LoadAllItemSlot();
    }




    void FixedUpdate()
    {
        Datasave.Instance.savedata.time -= Time.deltaTime;
        min = (int)Mathf.Floor(Datasave.Instance.savedata.time / 60);
        sec = (int)Mathf.Floor(Datasave.Instance.savedata.time % 60);
        timetext.text = min + " : " + sec.ToString("d2");//�ő包����2���Ɏw��B5��05�ɂȂ�B
        if (min == 0 && sec == 0)
        {
            if (!timestop)
            {
                Admob.GetComponent<Admobinterstitial>().ShowAdandToNEWplayscene();
                timestop = true;
            }
        }
        if (!Datasave.Instance.savedata.cooked)
        {
            if (Datasave.Instance.savedata.nabeclear)
            {
                cooktime += Time.deltaTime;
                if (cooktime >= 30)
                {
                    nabecollider.enabled=false;
                    Datasave.Instance.savedata.cooked = true;
                    Cooked();
                }
            }
        }

        AutosaveSystem(3);
    }

    void AutosaveSystem(int frequency)
    {
        if (sec % frequency == 1)
        {
            stopper = false;
        }

        if (!stopper)
        {
            if (sec % frequency == 0)
            {
                Debug.Log("save");
                Debug.Log(min + ":" + sec);
                Datasave.Instance.Save();
                stopper = true;
            }
        }
    }
    public void Gotitem(Data.tags tag)
    {

        for (int i = 0; i < Datasave.Instance.savedata.slotsData.Length; i++)
        {
            if (!Datasave.Instance.savedata.slotsdatabool[i])//�X���b�g�̃f�[�^����
            {
                soundManager.Getitem();
                Datasave.Instance.savedata.slotsData[i] = dataList.Returndata(tag);//�擾�����I�u�W�F�N�g�̃f�[�^������

                Debug.Log("�X���b�g"+i+"��"+ dataList.Returndata(tag).objname+"�̃f�[�^�����܂���");
                slotsImage[i].sprite = Datasave.Instance.savedata.slotsData[i].sprite;//�擾�����I�u�W�F�N�g�̉摜������
                Datasave.Instance.savedata.slotsdatabool[i] = true;
                break;
            }

        }

    }
    void Itemnametext(Data.tags tag)
    {
        
        if (tag == Data.tags.cup) itemnametext.text = "コップ";
        else if (tag == Data.tags.watercup) itemnametext.text = "水入りのコップ";
        else if (tag == Data.tags.remotocontrolleron) itemnametext.text = "リモコン";
        else if (tag == Data.tags.remotocontrolleroff) itemnametext.text = "リモコン";
        else if (tag == Data.tags.knife1) itemnametext.text = "包丁";
        else if (tag == Data.tags.knife2) itemnametext.text = "包丁";
        else if (tag == Data.tags.lighter) itemnametext.text = "ライター";
        else if (tag == Data.tags.smallflower) itemnametext.text = "花";
        else if (tag == Data.tags.orange) itemnametext.text = "みかん";
        else if (tag == Data.tags.icedkey) itemnametext.text = "鍵";
        else if (tag == Data.tags.safetyboxkey) itemnametext.text = "金庫の鍵";
        else if (tag == Data.tags.banana) itemnametext.text = "バナナ";
        else if (tag == Data.tags.pear) itemnametext.text = "洋梨";
        else if (tag == Data.tags.drawer1key) itemnametext.text = "引き出しの鍵";

    }
    public void Updateitem(Data.tags tag)
    {
        Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum] = dataList.Returndata(tag);//�I�𒆂̃X���b�g�̃f�[�^�������̃f�[�^�ɕύX
        Debug.Log(Datasave.Instance.savedata.selectslotnum);
        slotsImage[Datasave.Instance.savedata.selectslotnum].sprite = Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].sprite;
    }

    public void LoadAllItemSlot()
    {
        for (int i = 0; i < 8; i++)
        {
            switch (Datasave.Instance.savedata.slotsData[i].name)
            {
                case Data.tags.banana:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.banana).sprite;
                    break;

                case Data.tags.pear:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.pear).sprite;
                    break;
                case Data.tags.orange:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.orange).sprite;
                    break;
                case Data.tags.knife1:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.knife1).sprite;
                    break;
                case Data.tags.knife2:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.knife2).sprite;
                    break;
                case Data.tags.remotocontrolleron:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.remotocontrolleron).sprite;
                    break;
                case Data.tags.remotocontrolleroff:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.remotocontrolleroff).sprite;
                    break;
                case Data.tags.lighter:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.lighter).sprite;
                    break;
                case Data.tags.cup:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.cup).sprite;
                    break;
                case Data.tags.watercup:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.watercup).sprite;
                    break;
                case Data.tags.smallflower:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.smallflower).sprite;
                    break;
                case Data.tags.icedkey:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.icedkey).sprite;
                    break;
                case Data.tags.drawer1key:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.drawer1key).sprite;
                    break;
                case Data.tags.safetyboxkey:
                    slotsImage[i].sprite = dataList.Returndata(Data.tags.safetyboxkey).sprite;
                    break;
            }
        }
    }

    void UpdateItemslotsNull(int slotnum)
    {
        Debug.Log("�X���b�g�ԍ�" + slotnum + "�̃f�[�^���폜");
        Datasave.Instance.savedata.slotsData[slotnum] = null;
        Datasave.Instance.savedata.slotsdatabool[slotnum] = false;
        slotsImage[slotnum].sprite =null;
        slotsFrame[slotnum].SetActive(false);
        Datasave.Instance.savedata.selectslotnum = -1;//�X���b�g�I��ԍ�����ɂ���
        Datasave.Instance.savedata.preselectslotnum = -1;//�O�X���b�g�I��ԍ�����ɂ���
    }
    public void PressSlotRightButton()
    {
        soundManager.Selectslot();
        slotpanel1.SetActive(false);
        slotpanel2.SetActive(true);
    }

    public void PressSlotLeftButton()
    {
        soundManager.Selectslot();
        slotpanel1.SetActive(true);
        slotpanel2.SetActive(false);
    }
    public void TouchedSlot(int slotnum)
    {

        if (Datasave.Instance.savedata.slotsdatabool[slotnum])//�I�������X���b�g�̃f�[�^��null����Ȃ��ꍇ
        {
            Datasave.Instance.savedata.selectslotnum = slotnum;//�X���b�g�I��ԍ���ς���

            if (Datasave.Instance.savedata.selectslotnum == Datasave.Instance.savedata.preselectslotnum)//�ȑO�������X���b�g�Ɠ����X���b�g���������ꍇ
            {
                ShowSelectedItem(Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].name);
            }
            else //�ȑO�ƈႤ�X���b�g��I�������ꍇ
            {
                soundManager.Selectslot();
                if (Datasave.Instance.savedata.preselectslotnum != -1) slotsFrame[Datasave.Instance.savedata.preselectslotnum].SetActive(false);//�ȑO�������X���b�g��-1����Ȃ��Ƃ��ȑO�������X���b�g���A�N�e�B�u
                slotsFrame[Datasave.Instance.savedata.selectslotnum].SetActive(true);
            }

            Datasave.Instance.savedata.preselectslotnum = Datasave.Instance.savedata.selectslotnum;//�I�������X���b�g�ԍ��ɏ����ς���

        }
    }

    public void Touchslot0()
    {
        TouchedSlot(0);
    }
    public void Touchslot1()
    {
        TouchedSlot(1);
    }
    public void Touchslot2()
    {
        TouchedSlot(2);
    }
    public void Touchslot3()
    {
        TouchedSlot(3);
    }
    public void Touchslot4()
    {
        TouchedSlot(4);
    }
    public void Touchslot5()
    {
        TouchedSlot(5);
    }
    public void Touchslot6()
    {
        TouchedSlot(6);
    }
    public void Touchslot7()
    {
        TouchedSlot(7);
    }
    
    void ShowSelectedItem(Data.tags showitemtag)
    {
        
        Itemnametext(showitemtag);
        showitemimage.sprite = dataList.Returndata(showitemtag).sprite;
        showitempanel.SetActive(true);
        
    }
    public void BackShowSelectedItemPanel()
    {
        soundManager.Cancel();
        showitempanel.SetActive(false);
    }

    public void HideSelectedItemPanel()
    {
        showitempanel.SetActive(false);
    }


    public void TouchedItem(Data.tags tag)
    {
        string touchobjtagname;
        Debug.Log(tag);
        touchobjtagname = dataList.Returndata(tag).objname;
        if (touchobjtagname == "water") WaterManeger(tag);//�G�����I�u�W�F�����̎�
        else if (touchobjtagname == "flower1") PotManeger(tag);
        else if (touchobjtagname == "flower2") PotManeger(tag);
        else if (touchobjtagname == "flower3") PotManeger(tag);
        else if (touchobjtagname == "flower4") PotManeger(tag);
        else if (touchobjtagname == "airconditioner") AirconManeger();
        else if (touchobjtagname == "smallpot") SmallpotManager(tag);
        else if (touchobjtagname == "slidebutton1") SlidebuttonManager(tag);
        else if (touchobjtagname == "slidebutton2") SlidebuttonManager(tag);
        else if (touchobjtagname == "slidebutton3") SlidebuttonManager(tag);
        else if (touchobjtagname == "slidebutton4") SlidebuttonManager(tag);
        else if (touchobjtagname == "drawer4") DrawManager(Data.tags.drawer4);
        else if (touchobjtagname == "drawer2") DrawManager(Data.tags.drawer2);
        else if (touchobjtagname == "foodbutton1") FoodButtonManager(tag);
        else if (touchobjtagname == "foodbutton2") FoodButtonManager(tag);
        else if (touchobjtagname == "foodbutton3") FoodButtonManager(tag);
        else if (touchobjtagname == "foodbutton4") FoodButtonManager(tag);
        else if (touchobjtagname == "drawer3") DrawManager(tag);
        else if (touchobjtagname == "knifeblock") KnifeBlockManager();
        else if (touchobjtagname == "refrigerator") RefrigeratorManager(tag);
        else if (touchobjtagname == "keyshape") KeyshapeManager();
        else if (touchobjtagname == "door2") Door2Manager();
        else if (touchobjtagname == "candle") CandleManager();
        else if (touchobjtagname == "safetybox") SafetyboxManager();
        else if (touchobjtagname == "trashcanbutton1") TrashcanbuttonManager(tag);
        else if (touchobjtagname == "trashcanbutton2") TrashcanbuttonManager(tag);
        else if (touchobjtagname == "nabe") NabeManager();
        else if (touchobjtagname == "drawer1") Drawer1Manager(tag);
    }

    void Drawer1Manager(Data.tags tag)
    {
        if (Datasave.Instance.savedata.drawer1isunlock)
        {
            if (Watchatdetect(Data.tags.detect15))
            { 
                animaController.Draweranima(tag);
                drawer1collider.enabled = false;
            }
           
                
        }
        else if (!Datasave.Instance.savedata.drawer1isunlock)
        {
            if (Datasave.Instance.savedata.selectslotnum != -1)
            {
                if (Watchatdetect(Data.tags.detect17))
                {
                    if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "drawer1key")

                    {

                        UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);

                        detect17collider.enabled = false;


                        Datasave.Instance.savedata.drawer1isunlock = true;

                        drawer1keyanima.SetActive(true);

                        animaController.Drawer1unlock();

                    }
                }
            }

        }


    }
    void Cooked()
    {
        pearinnabe.SetActive(false);
        bananainnabe.SetActive(false);
        orangeinnabe.SetActive(false);
        drawer1key.SetActive(true);
    }
    void NabeManager()
    {
        if (Datasave.Instance.savedata.selectslotnum != -1)
        {
            if (!Datasave.Instance.savedata.nabeclear)
            {
                if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "watercup")
                {
                    if (!Datasave.Instance.savedata.fullwaterinnabe)
                    {
                        soundManager.Invoke("Addwater", 0.3f);
                        Datasave.Instance.savedata.fullwaterinnabe = true;
                        addwaterinnabeanima.SetActive(true);
                        Updateitem(Data.tags.cup);
                        animaController.Addwaterinnabe();
                    }
                }
                else if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "pear")
                {
                    if (Datasave.Instance.savedata.fullwaterinnabe)
                    {
                        soundManager.Addnabe();
                        pearinnabe.SetActive(true);
                        UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);
                        Datasave.Instance.savedata.putpear=true;
                    }
                }
                else if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "banana")
                {
                    if (Datasave.Instance.savedata.fullwaterinnabe)
                    {
                        soundManager.Addnabe();
                        bananainnabe.SetActive(true);
                        UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum); 
                        Datasave.Instance.savedata.putbanana = true;
                    }

                }
                else if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "orange")
                {
                    if (Datasave.Instance.savedata.fullwaterinnabe)
                    {
                        soundManager.Addnabe();
                        orangeinnabe.SetActive(true);
                        UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);
                        Datasave.Instance.savedata.putorange = true;
                    }
                }
                if ((Datasave.Instance.savedata.putorange&& Datasave.Instance.savedata.putpear)&& Datasave.Instance.savedata.putbanana) Datasave.Instance.savedata.nabeclear = true;

            }
        }
    }

    void TrashcanbuttonManager(Data.tags tag)
    {
        if (!cleartrashbutton)
        {
            soundManager.TouchtrashcanbuttonSE();
            if (tag == Data.tags.trashcanbutton1)
            {
                trashbutton1num++;
                if (trashbutton1num >= 10) trashbutton1num = 0;
                trashbutton1text.text = "" + trashbutton1num;

            }
            else
            {
                trashbutton2num++;
                if (trashbutton2num >= 10) trashbutton2num = 0;
                trashbutton2text.text = "" + trashbutton2num;
            }
            if (trashbutton1num == 9 && trashbutton2num == 9)
            {
                soundManager.ClearSE();
                cleartrashbutton = true;
                animaController.Opentrashcan();
            }
        }
        
    }
    void SafetyboxManager()
    {

        if (Datasave.Instance.savedata.safetyboxisunlocked)
        {
            safetyboxcollider.enabled = false;
            animaController.Safetyboxopen();
        }
        if (Datasave.Instance.savedata.selectslotnum != -1)
        {
            if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "safetyboxkey")
            {
                UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);
                Datasave.Instance.savedata.safetyboxisunlocked = true;
                safetyboxkeyanima.SetActive(true);
                animaController.Safetyboxunlock();
            }
        }
    }
    void CandleManager()
    {
        if (Datasave.Instance.savedata.selectslotnum != -1)
        {
            if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "lighter")
            {
                if (!candlefireison)
                {
                    lighteranima.SetActive(true);
                    animaController.Lighter();
                }
            }
        }
    }
    void Door2Manager()
    {

        if (Datasave.Instance.savedata.door2isunlock)
        {
            animaController.Opendoor2();
        }

        if (Watchatdetect(Data.tags.detect10))
        {
            if (Datasave.Instance.savedata.selectslotnum != -1)
            {


                if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "icedkey")
                {
                    if (!Datasave.Instance.savedata.door2isunlock)
                    {
                        Datasave.Instance.savedata.door2isunlock = true;
                        UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);
                        icedkeyanima.SetActive(true);
                        animaController.Unlockdoor2();
                    }
                }
            }
      
            if(!Datasave.Instance.savedata.door2isunlock)      
            {       
                soundManager.PlayunlockSE();
            }

            
        
        }
        

        
    }
    void KeyshapeManager()
    {
        if (!Datasave.Instance.savedata.clearicedkey)
        {
            if (!watershapeisfull)
            {
                if (Datasave.Instance.savedata.selectslotnum != -1)//�I���X���b�g�̃f�[�^���󂶂�Ȃ��Ƃ�
                {
                    if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "watercup")
                    {
                        watercup2.SetActive(true);
                        soundManager.Invoke("Addwater", 0.3f);
                        animaController.Pourwaterinkeyshape();
                    }
                }

            }
        }
    }
    void RefrigeratorManager(Data.tags tag)
    {
        animaController.DoorOpen(tag);
    }
    void KnifeBlockManager()
    {
        if (Datasave.Instance.savedata.selectslotnum != -1)//�I���X���b�g�̃f�[�^���󂶂�Ȃ��Ƃ�
        {     
            if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "knife1")//knife1�������Ă���Ƃ�
        
            {
                UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);
                animaController.Knife1Anima();
                Datasave.Instance.savedata.knife1clear = true;
       
            }
            else if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "knife2")//knife2�������Ă���Ƃ�

            {
                UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);
                animaController.Knife2Anima();
                Datasave.Instance.savedata.knife2clear = true;


            }
        }

       
    }

    public void KnifeClear()//���knife���N���A�������Ă΂��
    {
        if (Datasave.Instance.savedata.knife1clear && Datasave.Instance.savedata.knife2clear)
        {
            pear.SetActive(true);//knife���N���A������
        }
    }
    void FoodButtonManager(Data.tags tag)
    {
        if (!cleardrawer3)//�N���A���ĂȂ��Ƃ�
        {
            soundManager.TouchfoodbuttonSE();
            if (tag == Data.tags.foodbutton1)
            {
                foodimage1num++;
                if (foodimage1num >= 4) foodimage1num = 0;//�z��ԍ����ő�l�𒴂�����
                foodimage1.sprite = foodImages1[foodimage1num];
            }


            else if (tag == Data.tags.foodbutton2)
            {
                foodimage2num++;
                if (foodimage2num >= 4) foodimage2num = 0;//�z��ԍ����ő�l�𒴂�����
                foodimage2.sprite = foodImages2[foodimage2num];
            }
            else if (tag == Data.tags.foodbutton3)
            {
                foodimage3num++;
                if (foodimage3num >= 4) foodimage3num = 0;//�z��ԍ����ő�l�𒴂�����
                foodimage3.sprite = foodImages3[foodimage3num];
            }
            else if (tag == Data.tags.foodbutton4)
            {
                foodimage4num++;
                if (foodimage4num >= 4) foodimage4num = 0;//�z��ԍ����ő�l�𒴂�����
                foodimage4.sprite = foodImages4[foodimage4num];
            }
            if ((foodimage1num == 2 && foodimage2num == 3) && (foodimage3num == 0 && foodimage4num == 2))//�摜���������Ƃ�

            {
                soundManager.ClearSE();
                Cleardrawer3();
            }
       
        }
    }

    void Cleardrawer3()
    {
        detect18collider.enabled = false;
        cleardrawer3 = true;
    }
    void DrawManager(Data.tags tag)
    {
        
        animaController.Draweranima(tag);
        
        
    }

   
    
    
    void Cleardrawer4()
    {
        detect20collider.enabled = false;
        cleardrawer4 = true;
        soundManager.Invoke("ClearSE", 0.5f);
    }

    void SlidebuttonManager(Data.tags tag)
    {
        if (!cleardrawer4)
        {
            switch (dataList.Returndata(tag).objname)
            {
                case "slidebutton1":
                    if (slidebutton1 == true)//�X���C�h�{�^�����I���̎�
                    {
                        slidebutton1 = false;
                        animaController.SlidebuttonOff(tag);
                    }
                    else
                    {
                        slidebutton1 = true;
                        animaController.SlidebuttonOn(tag);
                    }
                    break;

                case "slidebutton2":
                    if (slidebutton2 == true)
                    {
                        slidebutton2 = false;
                        animaController.SlidebuttonOff(tag);
                    }
                    else
                    {
                        slidebutton2 = true;
                        animaController.SlidebuttonOn(tag);
                    }
                    break;

                case "slidebutton3":
                    if (slidebutton3 == true)
                    {
                        slidebutton3 = false;
                        animaController.SlidebuttonOff(tag);
                    }
                    else
                    {
                        slidebutton3 = true;
                        animaController.SlidebuttonOn(tag);
                    }
                    break;

                case "slidebutton4":
                    if (slidebutton4==true)
                    {
                        slidebutton4 = false;
                        animaController.SlidebuttonOff(tag);
                    }
                    else
                    {
                        slidebutton4 = true;
                        animaController.SlidebuttonOn(tag);
                    }
                    break;
            }
            
            if ((slidebutton1 == false && slidebutton2 == false) && (slidebutton3 == false && slidebutton4 == true))//�X���C�h�{�^���̏�������������
            {

                Cleardrawer4();
            }
        }
        
    }

    void WaterManeger(Data.tags tag)
    { 
        
        if (Datasave.Instance.savedata.selectslotnum != -1)//�I���X���b�g�̃f�[�^���󂶂�Ȃ��Ƃ�
        {
            if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "cup") animaController.AddwaterinCup() ;//�I�����Ă�X���b�g�ɃJ�b�v�����鎞
        }
        
    }
    void SmallpotManager(Data.tags tag)
    {
        if (Datasave.Instance.savedata.selectslotnum != -1)//�I���X���b�g�̃f�[�^���󂶂�Ȃ��Ƃ�
        {
            if (Datasave.Instance.savedata.existflower)//�Ԃ������Ă���Ƃ�
            {
                if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "watercup")//�R�b�v�������Ă���Ƃ�
                {
                    soundManager.Invoke("Addwater", 0.3f);
                    animaController.Pourwater();
                    animaController.Orangegrow();
                }


            }
            else
            {
                if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "smallflower")//�Ԃ������Ă���Ƃ�
                {
                    soundManager.Putflower();
                    Datasave.Instance.savedata.existflower = true;//�͂Ȃ��u���ꂽ
                    flower5.SetActive(true);//�ԕr�̉Ԃ��A�N�e�B�u��
                    UpdateItemslotsNull(Datasave.Instance.savedata.selectslotnum);//�Ԃ����[����Ă����X���b�g��null��
                }
            }


        }
    }
    void PotManeger(Data.tags tag)
    {
        if (Datasave.Instance.savedata.selectslotnum != -1)//�I���X���b�g�̃f�[�^���󂶂�Ȃ��Ƃ�
        {

            if (Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "watercup")
            {
                soundManager.Invoke("Addwater", 0.3f);
                animaController.Pourwater();
                animaController.Growflower(tag);
            }

        }
    }
    
    void AirconManeger()
    {
        if (Datasave.Instance.savedata.selectslotnum != -1)//�I���X���b�g�̃f�[�^���󂶂�Ȃ��Ƃ�
        {
 
            if ((Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "remotocontrolleron")||(Datasave.Instance.savedata.slotsData[Datasave.Instance.savedata.selectslotnum].objname == "remotocontrolleroff")) animaController.Remocon();//�I���X���b�g�������R���̎�
            

        }
    }


     public bool Watchatdetect(Data.tags tag)
    {
        if (stackTags.Peek() == tag) return true;
        else return false;
    }
    
    public void PreventtouchpanelOn()
    {
        preventtouchpanel.SetActive(true);
    }

    public void PreventtouchpanelOff()
    {
        preventtouchpanel.SetActive(false);
    }
    void Scenechangemaneger(Data.tags pretag, Data.tags tag)//�V�[���ړ�����ui,�J�����̋���
    {
        Vector3 tagPos;
        Vector3 tagRota;
        Vector3 pretagPos;
        Vector3 pretagRota;
        Data data;
        Data predata;

        data = dataList.Returndata(tag);
        predata = dataList.Returndata(pretag);

        tagPos = data.pos;
        tagRota = data.rota;
        pretagPos = predata.pos;
        pretagRota = predata.rota;

        if (tag == Data.tags.first)
        {

            ShowleftrightButton();
            HidebackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota-pretagRota,10));
        }
        else if(tag == Data.tags.detect1)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect2)
        {
            GameObject.Find("" + data.name).SetActive(false);
            ShowbackButton();
            HideleftrightButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect3)
        {
            GameObject.Find("" + data.name).SetActive(false);
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect4)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect5)
        {
            
            GameObject.Find(""+data.name).SetActive(false);
            
            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect6)
        {
            GameObject.Find("" + data.name).SetActive(false);
            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect7)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect8)
        {
            GameObject.Find("" + data.name).SetActive(false);
            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect9)
        {
            GameObject.Find("" + data.name).SetActive(false);


            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect10)
        {
            GameObject.Find("" + data.name).SetActive(false);
            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect11)
        {
            GameObject.Find("" + data.name).SetActive(false);
            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect12)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect13)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect14)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect15)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect16)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect17)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect18)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect20)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
                ShowbackButton();
                StartCoroutine(camcon.move(pretagPos, tagPos, 10));
                StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
          
        }
        else if (tag == Data.tags.detect21)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect22)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect23)
        {
            GameObject.Find("" + data.name).SetActive(false);

            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect24)
        {
            GameObject.Find("" + data.name).SetActive(false);

           
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect25)
        {
            GameObject.Find("" + data.name).SetActive(false);

            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect26)
        {
            GameObject.Find("" + data.name).SetActive(false);
            
          
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect27)
        {
            GameObject.Find("" + data.name).SetActive(false);

            
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect28)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect29)
        {
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect30)
        {
            
            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect31)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect32)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }
        else if (tag == Data.tags.detect33)
        {

            GameObject.Find("" + data.name).SetActive(false);
            HideleftrightButton();
            ShowbackButton();
            StartCoroutine(camcon.move(pretagPos, tagPos, 10));
            StartCoroutine(camcon.Rotatecamera(tagRota - pretagRota, 10));
        }

    }

    public void detected(Data.tags tag)
    {
        stackPreTags.Push(stackTags.Peek());//�O�ɐG�����I�u�W�F�N�g�̃^�O���L�^
        stackTags.Push(tag);//�G�����I�u�W�F�N�g�̃^�O���L�^
        Scenechangemaneger(stackPreTags.Peek(),stackTags.Peek()) ;//�G�����I�u�W�F�N�g��tag�ƑO�̃I�u�W�F�N�g��tag�������ɓ����
    }

    public void Back()
    {
        
        AllTagsSetactive(detectTagobjects, true);//detectsTag�t���̃I�u�W�F�N�g�����ׂăA�N�e�B�u�ɂ���
        Scenechangemaneger(stackTags.Pop(), stackPreTags.Pop());//������ꏊ����O�̏ꏊ�փV�[���`�F���W
       

    }

   public void AllTagsSetactive(GameObject[] tagObj, bool istrue)
    {
        foreach(GameObject gameObject in tagObj)gameObject.SetActive(istrue);
    }
    public void HideleftrightButton()
    {
        rightbutton.SetActive(false);
        leftbutton.SetActive(false);
    }

    public void HidebackButton()
    {
        backbutton.SetActive(false);
    }

    public void ShowbackButton()
    {
        backbutton.SetActive(true);
    }

    public void ShowleftrightButton()
    {
        rightbutton.SetActive(true);
        leftbutton.SetActive(true);
    }
    public void CameraRight()
    {
        StartCoroutine(camcon.Rotatecamera(new Vector3(0,90,0),10));
    }

    public void CameraLeft()
    {
       
        StartCoroutine(camcon.Rotatecamera(new Vector3(0,-90,0),10));
      
    }
    public void key1on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "1";
            }
        }
    }
    public void key2on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "2";
            }
        }

    }
    public void key3on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "3";
            }
        }
    }
    public void key4on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "4";
            }
        }
    }
    public void key5on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "5";
            }
        }
    }
    public void key6on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "6";
            }
        }
    }
    public void key7on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "7";
            }
        }
    }
    public void key8on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "8";
            }
        }
    }
    public void key9on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "9";
            }
        }
    }
    public void key0on()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keycount != 4)
            {
                soundManager.Touchpanelbutton();
                keycount++;
                keypadpaneltext.text += "0";
            }
        }
    }

    public void keyC()
    {
        if (!Datasave.Instance.savedata.allclear)
        {          
            soundManager.Touchpanelbutton();               
            keycount =0;
            keypadpaneltext.text= "";
            
        }
    }

    public void keyM()
    {
        if (!Datasave.Instance.savedata.allclear)
        {
            if (keypadpaneltext.text == "7363")
            {
                soundManager.ClearSE();
                Datasave.Instance.savedata.allclear = true;

            }
            else
            {
                soundManager.Cancel1();

            }
        }
    }
    public void AllClear()
    {
        soundManager.PlayopenSE();
        gameclearpanel.SetActive(true);
        StartCoroutine(fadeingameclearpanel());
        
    }
    IEnumerator fadeingameclearpanel()
    {
        while (gameclearpanelimage.color.a <= 1)
        {
            gameclearpanelimage.color += new Color(0, 0, 0, 0.03f);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(2f);
#if UNITY_IOS
        UnityEngine.iOS.Device.RequestStoreReview();
#endif
        backtotitlebutton.SetActive(true);
        Datasave.Instance.Initialization();
    }
    
}
