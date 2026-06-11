using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercupManeger : MonoBehaviour
{

    Data.tags cup;
    GameDirector gameDirector;
    public GameObject waterParticle;

    private void Awake()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        
    }
    void Start()
    {
        cup = Data.tags.cup;
        
        gameObject.SetActive(false);
    }

    public void WaterParticleOn()
    {

        waterParticle.SetActive(true);
    }

    public void WaterParticleOff()
    {
        waterParticle.SetActive(false);
    }
    public void EndPourWaterAnima()
    {
        gameDirector.Updateitem(cup);

        gameObject.SetActive(false);
        
        gameDirector.PreventtouchpanelOff();//âÊñ ÇêGÇÍÇÈÇÊÇ§Ç…Ç∑ÇÈ
    }
}
