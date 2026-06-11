using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public  class DataList:ScriptableObject
{
   
        public List<Data> datas = new List<Data>();

    public Data Returndata(Data.tags tag)//tag‚É‚æ‚Á‚Ädata‚ğ•Ô‚·
    {
        foreach (Data data in datas)
        {
            if (data.name == tag)
            {
                return data;
            }

        }
        return null;

    }
}
    

    
    


[System.Serializable]
public class Data
{
    public enum tags//¦tag‚Ì“r’†‚É‚ ‚½‚ç‚µ‚¢tag ‚ğ’Ç‰Á‚·‚é‚Ætag‚É•R‚Ã‚¯‚ç‚ê‚Ä‚¢‚éƒf[ƒ^‚ª‚·‚ê‚é‚Ì‚Å’ˆÓ
    {
        none,
        first,
        detect1,
        detect2,
        detect3,
        detect4,
        detect5,
        detect6,
        detect7,
        detect8,
        detect9,
        detect10,
        detect11,
        detect12,
        detect13,
        detect14,
        detect15,
        detect16,
        detect17,
        detect18,
        detect19,
        detect20,
        detect21,
        detect22,
        detect23,
        detect24,
        detect25,
        detect26,
        detect27,
        detect28,
        detect29,
        detect30,
        detect31,
        detect32,
        detect33,
        remotocontrolleron,
        
        candle,
        Pot1,
        Pot2,
        Pot3,
        Pot4,
        safetybox,
        airconditioner,
        cup,
        refrigerator,
        trashcan,
        water,
        drawer1,
        drawer2,
        drawer3,
        drawer4,
        door1,
        door2,
        knife1,
        lighter,
        smallpot,
        smallflower,
        nabe,
        pear,
        knifeblock,
        banana,
        slot1,
        slot2,
        slot3,
        slot4,
        slot5,
        slot6,
        slot7,
        slot8,
        watercup,
        orange,
        slidebutton1,
        slidebutton2,
        slidebutton3,
        slidebutton4,
        draw4,
        foodbutton1,
        foodbutton2,
        foodbutton3,
        foodbutton4,
        knife2,
        keyshape,
        icedkey,
        safetyboxkey,
        trashcanbutton1,
        trashcanbutton2,
        drawer1key,
        remotocontrolleroff,
        detect0,
    }
    public string objname;
    public tags name;
    public Vector3 pos;
    public Vector3 rota;
    public Sprite sprite;
}

