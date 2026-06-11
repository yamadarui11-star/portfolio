using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Savedata
{
    public bool dataexist = false;
    public bool[] slotsdatabool = { false, false, false, false, false, false, false, false };
    public Data[] slotsData = new Data[8];
    public bool mugget = false;
    public bool smallflowerget = false;
    public bool remoconget = false;
    public bool orangeget = false;
    public bool pearget = false;
    public bool bananaget = false;
    public bool lighterget = false;
    public bool knife1get = false;
    public bool knife2get = false;
    public bool icedkeyget = false;
    public bool drawer1keyget = false;
    public bool safetyboxkeyget = false;
    public bool fullwaterinnabe = false;
    public bool airconison = true;
    public bool clearicedkey = false;
    public bool door2isunlock = false;
    public bool knife1clear = false;
    public bool knife2clear = false;
    public float time = 301f;
    public bool clearcandle = false;
    public bool existflower = false;
    public bool safetyboxisunlocked = false;
    public bool nabeclear = false;
    public bool putpear = false;
    public bool putbanana = false;
    public bool putorange = false;
    public bool cooked = false;
    public bool drawer1isunlock = false;
    public bool allclear = false;

    public int menubuttonclick = 0;
    public int preselectslotnum = -1;
    public int selectslotnum=-1;
}
