using TMPro;
using UnityEngine;

public class TitleDirector : MonoBehaviour
{
    public bool canShowLevelBoostAd;
    public static TitleDirector instance;
    public GameObject panel_speedLevelUp;
    public GameObject panel_sizeLevelUp;
    public GameObject panel_main;
    public GameObject panel_unlockNewStage;
    public GameObject panel_levelUPBoost;
    [SerializeField] TextMeshProUGUI text_massToLevelUpSpeed;
    [SerializeField] TextMeshProUGUI text_massToLevelUpSize;
    [SerializeField] TextMeshProUGUI text_massToUnlockNewStage;
    [SerializeField] TextMeshProUGUI text_massAfterLevelUpSpeed;
    [SerializeField] TextMeshProUGUI text_massAfterLevelUpSize;
    [SerializeField] TextMeshProUGUI text_massAfterUnlockStage;

    [SerializeField] TextMeshProUGUI text_score1;
    [SerializeField] TextMeshProUGUI text_score2;
    [SerializeField] TextMeshProUGUI text_score3;
    [SerializeField] TextMeshProUGUI text_score4;


    [SerializeField] TextMeshProUGUI text_speedLevel;
    [SerializeField] TextMeshProUGUI text_nextSpeedLevel;
    [SerializeField] TextMeshProUGUI text_sizeLevel;
    [SerializeField] TextMeshProUGUI text_nextSizeLevel;
    [SerializeField] TextMeshProUGUI text_maxStage;
    [SerializeField] TextMeshProUGUI text_nextMaxStage;
    [SerializeField] TextMeshProUGUI text_boostingNum;
    [SerializeField] GameObject boostingTextObj;
    [SerializeField] GameObject levelBoostButton;

    public event System.Action updateUI;
    [System.NonSerialized] public int massScore_toSizeLevelUp;
    [System.NonSerialized] public int massScore_toSpeedLevelUp;
    [System.NonSerialized] public int massScore_toUnlockNewStage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

        AppstoreReview();
        panel_speedLevelUp.SetActive(false);
        panel_sizeLevelUp.SetActive(false);
        panel_unlockNewStage.SetActive(false);
        updateUI += UpdateUI;
        updateUI += UpdateMassScoreToLevelUp;
        updateUI += UpdateUIColor;
        updateUI.Invoke();

        ShowInterstitialAdOrNot();
    }

    private void AppstoreReview()
    {
        if (SavedataInstance.instance.savedata.playNum == 20)
        {
#if UNITY_IOS
            UnityEngine.iOS.Device.RequestStoreReview();
#endif
        }
    }
    private void ShowInterstitialAdOrNot()
    {
        if (SavedataInstance.instance.savedata.backToTitleNum >= 4)
        {
            InterstisialAdSctipt.instance.ShowAd();
        }
    }
    public void ResetBackToTitleNum()
    {
        SavedataInstance.instance.savedata.backToTitleNum = 0;
        SavedataInstance.instance.Save();
    }
    public void SpeedLevelUp()
    {
        if (massScore_toSpeedLevelUp <= SavedataInstance.instance.savedata.ownMassScore)
        {
            SavedataInstance.instance.savedata.ownMassScore -= massScore_toSpeedLevelUp;
            SavedataInstance.instance.savedata.playerSpeed_Level++;
            SavedataInstance.instance.Save();
            Invoke_UpdateUI();
            SoundManager.instance.PlaySE(SoundManager.audioClips_type.levelup);

        }
    }
    public void SizeLevelUp()
    {
        if (massScore_toSizeLevelUp <= SavedataInstance.instance.savedata.ownMassScore)
        {
            SavedataInstance.instance.savedata.ownMassScore -= massScore_toSizeLevelUp;
            SavedataInstance.instance.savedata.playerSize_Level++;
            SavedataInstance.instance.Save();
            Invoke_UpdateUI();
            SoundManager.instance.PlaySE(SoundManager.audioClips_type.levelup);

        }
    }

    public void UnlockNewStage()
    {
        if (massScore_toUnlockNewStage <= SavedataInstance.instance.savedata.ownMassScore)
        {
            SavedataInstance.instance.savedata.ownMassScore -= massScore_toUnlockNewStage;
            SavedataInstance.instance.savedata.maxStage++;
            SavedataInstance.instance.Save();
            Invoke_UpdateUI();
            SoundManager.instance.PlaySE(SoundManager.audioClips_type.levelup);
        }
    }
    public void Invoke_UpdateUI()
    {
        updateUI.Invoke();
    }
    private void UpdateUIColor()
    {
        if(massScore_toSpeedLevelUp > SavedataInstance.instance.savedata.ownMassScore) text_massAfterLevelUpSpeed.color = Color.red;
        else text_massAfterLevelUpSpeed.color = Color.white;
        if (massScore_toSizeLevelUp > SavedataInstance.instance.savedata.ownMassScore)  text_massAfterLevelUpSize.color = Color.red;
        else text_massAfterLevelUpSize.color = Color.white;
        if (massScore_toUnlockNewStage > SavedataInstance.instance.savedata.ownMassScore) text_massAfterUnlockStage.color = Color.red;
        else text_massAfterUnlockStage.color = Color.white;

    }
    private void UpdateUI()
    {
        text_score1.text = SavedataInstance.instance.savedata.ownMassScore.ToString();
        text_score2.text = SavedataInstance.instance.savedata.ownMassScore.ToString();
        text_score3.text = SavedataInstance.instance.savedata.ownMassScore.ToString();
        text_score4.text = SavedataInstance.instance.savedata.ownMassScore.ToString();
        text_speedLevel.text = "Lv "+SavedataInstance.instance.savedata.playerSpeed_Level.ToString();
        text_sizeLevel.text = "Lv "+SavedataInstance.instance.savedata.playerSize_Level.ToString();
        text_nextSpeedLevel.text = "Lv "+(SavedataInstance.instance.savedata.playerSpeed_Level+ 1).ToString();
        text_nextSizeLevel.text = "Lv "+(SavedataInstance.instance.savedata.playerSize_Level + 1).ToString();
        text_maxStage.text = "stage" + SavedataInstance.instance.savedata.maxStage.ToString();
        text_nextMaxStage.text = "stage" + (SavedataInstance.instance.savedata.maxStage + 1).ToString();
        if (SavedataInstance.instance.savedata.boostTime > 0)
        {
            boostingTextObj.SetActive(true);
            text_boostingNum.text = SavedataInstance.instance.savedata.boostTime.ToString();

        }
        else
        {
            boostingTextObj.SetActive(false);
        }
    }
    private void UpdateMassScoreToLevelUp()
    {
        massScore_toSizeLevelUp = GetmassScoreToLevelUp(SavedataInstance.instance.savedata.playerSize_Level);
        massScore_toSpeedLevelUp = GetmassScoreToLevelUp(SavedataInstance.instance.savedata.playerSpeed_Level);
        massScore_toUnlockNewStage= GetmassScoreToLevelUp(SavedataInstance.instance.savedata.maxStage*4);
        text_massToLevelUpSize.text = "-"+ massScore_toSizeLevelUp.ToString();
        text_massToLevelUpSpeed.text = "-"+massScore_toSpeedLevelUp.ToString();
        text_massToUnlockNewStage.text = "-"+massScore_toUnlockNewStage.ToString();
        text_massAfterLevelUpSize.text = (SavedataInstance.instance.savedata.ownMassScore - massScore_toSizeLevelUp).ToString();
        text_massAfterLevelUpSpeed.text = (SavedataInstance.instance.savedata.ownMassScore -massScore_toSpeedLevelUp).ToString();
        text_massAfterUnlockStage.text = (SavedataInstance.instance.savedata.ownMassScore - massScore_toUnlockNewStage).ToString();

    }
    private int GetmassScoreToLevelUp(int level)
    {
        return (int)Mathf.Pow((level - 1),2.5f) + 5;
    }
    private void Update()
    {
        if (canShowLevelBoostAd)
        {
            levelBoostButton.SetActive(true);
        }
        else
        {
            levelBoostButton.SetActive(false);
        }
    }
}
