using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttonfunction : MonoBehaviour
{
    [SerializeField] GameObject fadePamel;
    Image fadePanelImage;
    
    private void Start()
    {
        fadePanelImage = fadePamel.GetComponent<Image>();
        fadePamel.SetActive(false);
    }
    public void ShowRewardAd()
    {
        RewardAd.instance.ShowRewardAd();
    }
    public void ShowPanel_LevelUPBoost()
    {
        TitleDirector.instance.panel_levelUPBoost.SetActive(true);
    }
    public void HidePanel_LevelUPBoost()
    {
        TitleDirector.instance.panel_levelUPBoost.SetActive(false);
    }
    
    public void SE_Play()
    {
        SoundManager.instance.PlaySE(SoundManager.audioClips_type.play);

    }
    public void SE_LevelUP()
    {
        SoundManager.instance.PlaySE(SoundManager.audioClips_type.levelup);

    }
    public void SE_Button()
    {
        SoundManager.instance.PlaySE(SoundManager.audioClips_type.button);
    }
    public void SE_Cancel()
    {
        SoundManager.instance.PlaySE(SoundManager.audioClips_type.cancel);
    }
    public void UnlockNewStage()
    {
        TitleDirector.instance.UnlockNewStage();
    }
    public void SpeedLevelUp()
    {
        TitleDirector.instance.SpeedLevelUp();
    }
    public void SizeLevelUp()
    {
        TitleDirector.instance.SizeLevelUp();   
    }
    public void PlayGame()
    {
        SavedataInstance.instance.savedata.playNum++;
        SavedataInstance.instance.Save();
        Scenechange("GameScene");
    }
    
    
    public void ShowPanel_UnlockNewStage()
    {
        TitleDirector.instance.panel_unlockNewStage.SetActive(true);
    }
    public void HidePanel_UnlockNewStage()
    {
        TitleDirector.instance.panel_unlockNewStage.SetActive(false);
    }
    public void ShowPanel_SizeLevelUp()
    {
        TitleDirector.instance.panel_sizeLevelUp.SetActive(true);
    }
    public void HidePanel_SizeLevelUp()
    {
        TitleDirector.instance.panel_sizeLevelUp.SetActive(false);
    }
    public void ShowPanel_SpeedLevelUp()
    {
        TitleDirector.instance.panel_speedLevelUp.SetActive(true);
    }
    public void HidePanel_SpeedLevelUp()
    {
        TitleDirector.instance.panel_speedLevelUp.SetActive(false);
    }
    public void ShowPanel_Main()
    {
        TitleDirector.instance.panel_main.SetActive(true);
    }
    public void HidePanel_Main()
    {
        TitleDirector.instance.panel_main.SetActive(false);
    }
    private void Scenechange(string scene)
    {
        StartCoroutine(SceneFadeChange(scene));
    }
    IEnumerator SceneFadeChange(string scene)
    {
        fadePamel.SetActive(true);
        float a = fadePanelImage.color.a;
        while (fadePanelImage.color.a <= 1)
        {
            a += 0.05f;
            fadePanelImage.color = new(default, default, default, a);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(scene);
    }
    
}
