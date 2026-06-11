using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectController : MonoBehaviour
{
    
    GameDirector gamedirector;
    public Data.tags thisTag;

    
    public void detect()
    {
        Debug.Log("detect" + thisTag);
        if (!CameraController.isrotate)//cameraÇ™âÒÇ¡ÇƒÇ¢Ç»Ç¢Ç∆Ç´
        {
            if (thisTag == Data.tags.detect29)
            {
                if (gamedirector.refrigeratordoorisopen)
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect3)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect2))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect10)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect1))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect2)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect1))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect6)
            {
                if (gamedirector.Watchatdetect(Data.tags.first))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect8)
            {
                if (gamedirector.Watchatdetect(Data.tags.first))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect11)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect8))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect12)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect8))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect13)
            {
                if (!gamedirector.refrigeratordoorisopen)
                {
                    if (gamedirector.Watchatdetect(Data.tags.detect12))
                    {
                        gamedirector.detected(thisTag);
                    }
                }
            }
            else if (thisTag == Data.tags.detect14)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect15))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect15)
            {
                if (!gamedirector.refrigeratordoorisopen)
                {
                    if (gamedirector.Watchatdetect(Data.tags.detect12))
                    {
                        gamedirector.detected(thisTag);
                    }

                }
            }
            else if (thisTag == Data.tags.detect16)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect15))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect17)
            {
                    if (gamedirector.Watchatdetect(Data.tags.detect15))
                    {
                        gamedirector.detected(thisTag);
                    }
                
                
            }
            else if (thisTag == Data.tags.detect18)
            {
                    if (gamedirector.Watchatdetect(Data.tags.detect15))
                    {
                        gamedirector.detected(thisTag);
                    }
            }
            else if (thisTag == Data.tags.detect20)
            {
                    if (gamedirector.Watchatdetect(Data.tags.detect15))
                    {
                        gamedirector.detected(thisTag);
                    }
            }
            else if (thisTag == Data.tags.detect21)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect12))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect28)
            {
                    if (gamedirector.Watchatdetect(Data.tags.detect21))
                    {
                        gamedirector.detected(thisTag);
                    }
            }
            else if (thisTag == Data.tags.detect22)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect5))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect23)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect5))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect24)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect5))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect25)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect5))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect26)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect5))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect27)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect5))
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect30)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect10) == true && gamedirector.door2isope == true)
                {
                    gamedirector.detected(thisTag);
                }
            }
            else if (thisTag == Data.tags.detect31)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect13)) gamedirector.detected(thisTag);
            }
            else if (thisTag == Data.tags.detect32)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect7)&&gamedirector.safetyboxisopen) gamedirector.detected(thisTag);
            }
            else if (thisTag == Data.tags.detect33)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect15)&&gamedirector.drawer1isopen) gamedirector.detected(thisTag);
            }
            else if (thisTag == Data.tags.detect0)
            {
                if (Datasave.Instance.savedata.allclear&&gamedirector.Watchatdetect(Data.tags.detect2))
                {
                   gamedirector.AllClear();
                }
            }
            else
            {
                gamedirector.detected(thisTag);
            }
        }
        
    }

    public void Getitem()
    {
        Debug.Log("touchitem:" + thisTag);
        if (!CameraController.isrotate)
        {
            if (thisTag == Data.tags.smallflower)//smallflowerÇèEÇ§Ç∆Ç´
            {
                if (gamedirector.drawer4isopen)//draw4Ç™Ç†Ç¢ÇƒÇ¢ÇÈÇ∆Ç´
                {

                    if (gamedirector.Watchatdetect(Data.tags.detect15))//detect15Ç©ÇÁå©ÇƒÇ¢ÇÈÇ∆Ç´
                    {

                        gamedirector.Gotitem(thisTag);
                        Savegetitems.SaveItem(thisTag);
                        gameObject.SetActive(false);

                    }


                }
            }
            else if (thisTag == Data.tags.knife1)//knife1ÇèEÇ§Ç∆Ç´
            {
                if (gamedirector.drawer3isopen)//draw3Ç™Ç†Ç¢ÇƒÇ¢ÇÈÇ∆Ç´
                {

                    if (gamedirector.Watchatdetect(Data.tags.detect15))//detect15Ç©ÇÁå©ÇƒÇ¢ÇÈÇ∆Ç´
                    {

                        gamedirector.Gotitem(thisTag);
                        Savegetitems.SaveItem(thisTag);
                        gameObject.SetActive(false);

                    }


                }
            }
            else if (thisTag == Data.tags.icedkey)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect29))
                {
                    gamedirector.Gotitem(thisTag);
                    Savegetitems.SaveItem(thisTag);
                    gameObject.SetActive(false);

                }
            }
            else if (thisTag == Data.tags.lighter)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect30))
                {
                    gamedirector.Gotitem(thisTag);
                    Savegetitems.SaveItem(thisTag);
                    gameObject.SetActive(false);
                }
            }
            else if (thisTag == Data.tags.knife2)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect30))
                {
                    gamedirector.Gotitem(thisTag);
                    Savegetitems.SaveItem(thisTag);
                    gameObject.SetActive(false);
                }
            }
            else if (thisTag == Data.tags.safetyboxkey)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect23))
                {
                    gamedirector.Gotitem(thisTag);
                    Savegetitems.SaveItem(thisTag);
                    gameObject.SetActive(false);
                }
            }
            else if (thisTag == Data.tags.remotocontrolleron)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect22))
                {
                    gamedirector.Gotitem(thisTag);
                    Savegetitems.SaveItem(thisTag);
                    gameObject.SetActive(false);
                }
            }
            else if (thisTag == Data.tags.banana)
            {
                if (gamedirector.cleartrashbutton)
                {
                    if (gamedirector.Watchatdetect(Data.tags.detect28))
                    {
                        gamedirector.Gotitem(thisTag);
                        Savegetitems.SaveItem(thisTag);
                        gameObject.SetActive(false);
                    }
                }
              
            }
            else if (thisTag == Data.tags.pear)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect16))
                {
                    gamedirector.Gotitem(thisTag);
                    Savegetitems.SaveItem(thisTag);
                    gameObject.SetActive(false);
                }
            }
            else if (thisTag == Data.tags.orange)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect9))
                {
                    gamedirector.Gotitem(thisTag);
                    Savegetitems.SaveItem(thisTag);
                    gameObject.SetActive(false);
                }
            }
            else if(thisTag == Data.tags.drawer1key)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect13))
                {
                    if (Datasave.Instance.savedata.cooked == true)
                    {
                        gamedirector.Gotitem(thisTag);
                        Savegetitems.SaveItem(thisTag);
                        gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                gamedirector.Gotitem(thisTag);
                Savegetitems.SaveItem(thisTag);
                gameObject.SetActive(false);
            }
        }

    }

    public void TouchItem()
    {
        if(thisTag == Data.tags.keyshape)//keyshapeÇêGÇ¡ÇΩÇ∆Ç´
        {
           
            if (gamedirector.refrigeratordoorisopen)//ÉhÉAÇ™ãÛÇ¢ÇƒÇÈÇ∆Ç´
            {
                if (gamedirector.Watchatdetect(Data.tags.detect29))
                {
                    gamedirector.TouchedItem(thisTag);
                }
                
            }
        }
        else if (thisTag == Data.tags.nabe)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect13))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.door2)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect10)|| gamedirector.Watchatdetect(Data.tags.detect1))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.candle)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect23))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.airconditioner)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect6))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.Pot2)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect24))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.Pot3)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect25))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.Pot4)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect26))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.Pot1)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect27))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.smallpot)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect9))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.safetybox)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect7))
            {
                if (!gamedirector.safetyboxisopen)
                {
                    gamedirector.TouchedItem(thisTag);
                }
            }
        }
        else if (thisTag == Data.tags.refrigerator)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect11)|| gamedirector.Watchatdetect(Data.tags.detect12))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.knifeblock)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect16))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.water)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect14))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.drawer1)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect17)==true|| gamedirector.Watchatdetect(Data.tags.detect15) == true)
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.drawer2)
        {
            if (gamedirector.Watchatdetect(Data.tags.detect15))
            {
                gamedirector.TouchedItem(thisTag);
            }
        }
        else if (thisTag == Data.tags.drawer3)
        {
            if (gamedirector.cleardrawer3)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect15))
                {
                    gamedirector.TouchedItem(thisTag);
                }
                
            }
        }
        else if (thisTag == Data.tags.drawer4)
        {
            if (gamedirector.cleardrawer4)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect15))
                {
                    
                    gamedirector.TouchedItem(thisTag);
                }

            }
        }
        else if (thisTag == Data.tags.trashcanbutton1)
        {

            if (!gamedirector.cleartrashbutton)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect28))
                {
                    gamedirector.TouchedItem(thisTag);
                }
            }
        }
        else if (thisTag == Data.tags.trashcanbutton2)
        {
            if (!gamedirector.cleartrashbutton)
            {
                if (gamedirector.Watchatdetect(Data.tags.detect28))
                {
                    gamedirector.TouchedItem(thisTag);
                }
            }
        }
        else gamedirector.TouchedItem(thisTag);
        
    }

    void Start()
    {

        gamedirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

}
