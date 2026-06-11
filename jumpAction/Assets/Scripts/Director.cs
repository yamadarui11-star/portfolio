using UnityEngine;
using TMPro;
using System.Collections;
public class Director : MonoBehaviour
{
    public StageDataBase stageDataBase;
    [SerializeField] GameObject panel_goal;
    [SerializeField] GameObject panel_start;
    [SerializeField] GameObject panel_respawn;
    [SerializeField] GameObject panel_game;
    [SerializeField] GameObject panel_gameMenu;
    public static Director instance;
    public event System.Action onGoal;
    public event System.Action onStartScreen;
    [System.NonSerialized]
    public StageData.Type selectedStage=StageData.Type.stage1;
    int selectedStageNum=1;
    int getStar;
    int sum_star;
    [SerializeField] GameObject stage_wood;
    [SerializeField] GameObject stage_stone;
    [SerializeField] GameObject map1;
    [SerializeField] GameObject map2;
    [SerializeField] GameObject map3;
    [SerializeField] GameObject map4;
    [SerializeField] GameObject map5;
    [SerializeField] GameObject map6;
    [SerializeField] GameObject map7;
    [SerializeField] GameObject map8;
    [SerializeField] GameObject map9;
    [SerializeField] GameObject map10;
    [SerializeField] GameObject map11;
    [SerializeField] GameObject map12;
    [SerializeField] GameObject map13;
    [SerializeField] GameObject map14;
    [SerializeField] GameObject map15;


    [SerializeField] GameObject Button_stage1;
    [SerializeField] GameObject Button_stage2;
    [SerializeField] GameObject Button_stage3;
    [SerializeField] GameObject Button_stage4;
    [SerializeField] GameObject Button_stage5;
    [SerializeField] GameObject Button_stage6;
    [SerializeField] GameObject Button_stage7;
    [SerializeField] GameObject Button_stage8;
    [SerializeField] GameObject Button_stage9;
    [SerializeField] GameObject Button_stage10;
    [SerializeField] GameObject Button_stage11;
    [SerializeField] GameObject Button_stage12;
    [SerializeField] GameObject Button_stage13;
    [SerializeField] GameObject Button_stage14;
    [SerializeField] GameObject Button_stage15;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Button_Respawn;
    [SerializeField] GameObject Button_SetRespawn;
    [SerializeField] GameObject particle_respawn;
    
    [SerializeField] TextMeshProUGUI text_ResultTime;
    [SerializeField] TextMeshProUGUI text_ResultStage;

    [SerializeField] Animator ResultImage;
    [SerializeField] Animator resultstar1;
    [SerializeField] Animator resultstar2;
    [SerializeField] Animator resultstar3;
    [SerializeField] GameObject button_backToStart;

    [SerializeField] TextMeshProUGUI text_stageNum;
    [SerializeField] TextMeshProUGUI bestTime;

    [SerializeField] GameObject startButton;
    [SerializeField] TextMeshProUGUI text_conditionToStart;
    [SerializeField] Animator anima_paper;

    [SerializeField] GameObject star_paper;


    GameObject particle_respawn_obj;

    float respawnTime;
    bool setSpawnPoint=false;
    Vector2 spawnPoint;

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
        onStartScreen += UpdatePaperText_Stage;
        onStartScreen += UpdateBestScoreText;
        onStartScreen += SetActiveStartButton;
        onStartScreen += SetAvtiveButton_Stage;
        onStartScreen += AppReview;
        onGoal += SaveStageClearData;
        onGoal += SetActivePanel_Goal;
        onGoal += UpdateResultStageText;
        onGoal += UpdateResultTimeText;
        onGoal += StartResultCourtin;
        onGoal += GoalCount;
    }

    private void Start()
    {
        
        Application.targetFrameRate = 60;
    }
    private void AppReview()
    {
      
        if (SavedateInstance.instance.savedate.goalCount >= 10)
        {
#if UNITY_IOS
            UnityEngine.iOS.Device.RequestStoreReview();
#endif
            SavedateInstance.instance.savedate.goalCount = 0;
            SavedateInstance.instance.Save();
        }
    }
    private void GoalCount()
    {
        SavedateInstance.instance.savedate.goalCount++;
        SavedateInstance.instance.Save();

    }
    public void InvokeOnStartScreen()
    {
        onStartScreen.Invoke();
    }
    private int GetStar(StageData.Type stage)
    {
        StageData stageData = stageDataBase.GetStageData(stage);
        
        
        if (TimeController.instance.time < stageData.time_star3) return 3;
        else if (TimeController.instance.time < stageData.time_star2) return 2;
        else if (TimeController.instance.time < stageData.time_star1) return 1;
        else return 0;

    }
    private void SetActivePanel_Goal()
    {
        panel_goal.SetActive(true);
    }
    private void SaveStageClearData()
    {
        SavedateInstance.instance.SaveStageClearData(selectedStage, true, TimeController.instance.time, getStar=GetStar(selectedStage));
    }
    public void InvokeOnGoal()
    {
        onGoal.Invoke();
    }
    public void UpdateSelectedStage(StageData.Type stage)
    {
        selectedStage = stage;
        selectedStageNum = stageDataBase.GetStageData(stage).stageNum;
    }
    public void UpdatePaperText_Stage()
    {
        text_stageNum.text = selectedStageNum.ToString();
    }
    public void SetActiveMap()
    {
        if (1 <= selectedStageNum && selectedStageNum <= 10) stage_wood.SetActive(!stage_wood.activeSelf);
        else if (10 < selectedStageNum && selectedStageNum <= 15) stage_stone.SetActive(!stage_stone.activeSelf);
        switch (selectedStageNum)
        {
            case 1:
                map1.SetActive(!map1.activeSelf);
                break;
            case 2:
                map2.SetActive(!map2.activeSelf);
                break;
            case 3:
                map3.SetActive(!map3.activeSelf);
                break;
            case 4:
                map4.SetActive(!map4.activeSelf);
                break;
            case 5:
                map5.SetActive(!map5.activeSelf);
                break;
            case 6:
                map6.SetActive(!map6.activeSelf);
                break;
            case 7:
                map7.SetActive(!map7.activeSelf);
                break;
            case 8:
                map8.SetActive(!map8.activeSelf);
                break;
            case 9:
                map9.SetActive(!map9.activeSelf);
                break;
            case 10:
                map10.SetActive(!map10.activeSelf);
                break;
            case 11:
                map11.SetActive(!map11.activeSelf);
                break;
            case 12:
                map12.SetActive(!map12.activeSelf);
                break;
            case 13:
                map13.SetActive(!map13.activeSelf);
                break;
            case 14:
                map14.SetActive(!map14.activeSelf);
                break;
            case 15:
                map15.SetActive(!map15.activeSelf);
                break;
        }
    }

    public void SetAvtiveButton_Stage()
    {
        Button_stage1.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage1) != null) Button_stage2.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage2) != null) Button_stage3.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage3) != null) Button_stage4.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage4) != null) Button_stage5.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage5) != null) Button_stage6.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage6) != null) Button_stage7.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage7) != null) Button_stage8.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage8) != null) Button_stage9.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage9) != null) Button_stage10.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage10) != null) Button_stage11.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage11) != null) Button_stage12.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage12) != null) Button_stage13.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage13) != null) Button_stage14.SetActive(true);
        if (SavedateInstance.instance.GetStageClearData(StageData.Type.stage14) != null) Button_stage15.SetActive(true);

    }


    
    public void SetSpawnPoint()
    {
        if (!setSpawnPoint)
        {
            setSpawnPoint = true;
            spawnPoint = player.transform.position;
            respawnTime = TimeController.instance.time;
            particle_respawn_obj= Instantiate(particle_respawn, spawnPoint-new Vector2(0,0.5f), Quaternion.identity);
            
        }
        Button_SetRespawn.SetActive(false);
        Button_Respawn.SetActive(true);
    }
    public void ResetSpawnPoint()
    {
        setSpawnPoint = false;
        spawnPoint = new Vector2(0,0);
        respawnTime = 0;
        Destroy(particle_respawn_obj);
        Button_SetRespawn.SetActive(true);
        Button_Respawn.SetActive(false);
    }
    public void ReStartSpawnPoint()
    {
        if (setSpawnPoint)
        {
            player.transform.position = spawnPoint;
            TimeController.instance.time = respawnTime;
        }
    }

    private void UpdateResultTimeText()
    {
        text_ResultTime.text = TimeController.instance.time.ToString("f2");
    }
    private void UpdateResultStageText()
    {
        text_ResultStage.text = stageDataBase.GetStageData(selectedStage).stageNum.ToString();
    }
    private void StartResultCourtin()
    {
        StartCoroutine(ResultCourtin());
    }

    private IEnumerator ResultCourtin()
    {
        InitializeResultAnima();
        yield return new WaitForSeconds(1);
        ResultImage.Play("ResultImage");
        yield return new WaitForSeconds(0.5f);
        AudioSE.instance.Result();
        yield return new WaitForSeconds(0.5f);
        if (getStar == 3)
        {
            resultstar1.Play("StarGet");
            AudioSE.instance.PianoA();
            yield return new WaitForSeconds(0.5f);

            resultstar2.Play("StarGet");
            AudioSE.instance.PianoB();
            yield return new WaitForSeconds(0.5f);

            resultstar3.Play("StarGet");
            AudioSE.instance.PianoC();
        }
        else if(getStar == 2)
        {
            resultstar1.Play("StarGet");
            AudioSE.instance.PianoA();
            yield return new WaitForSeconds(0.5f);
            
            resultstar2.Play("StarGet");
            AudioSE.instance.PianoB();
        }
        else if (getStar == 1)
        {
            resultstar1.Play("StarGet");
            AudioSE.instance.PianoA();
        }

        yield return new WaitForSeconds(1f);
        button_backToStart.SetActive(true);
    }
    private  void InitializeResultAnima()
    {
        resultstar1.Play("idle_ResultStar");
        resultstar2.Play("idle_ResultStar");
        resultstar3.Play("idle_ResultStar");
        ResultImage.Play("idle_outofscreen");
        button_backToStart.SetActive(false);

    }
    public void UpdateBestScoreText()
    {

        StageClearDate selectedStageClearDate;
        selectedStageClearDate = SavedateInstance.instance.GetStageClearData(selectedStage);

        if (selectedStageClearDate != null)
        {
            bestTime.text = selectedStageClearDate.bestclearTime.ToString();
        }
        else
        {
            bestTime.text = "---";
        }
    }
    public void SetActiveStartButton()
    {
        sum_star = StarSum();
        switch (selectedStage)
        {

            case StageData.Type.stage11:
                if (22 <= sum_star)
                {
                    startButton.SetActive(true);
                }
                else
                {
                    text_conditionToStart.text = sum_star+"/22";
                    startButton.SetActive(false);

                }
                break;
            case StageData.Type.stage12:
                if (26 <= sum_star)
                {
                    startButton.SetActive(true);
                }
                else
                {
                    text_conditionToStart.text = sum_star + "/26";
                    startButton.SetActive(false);

                }
                break;
            case StageData.Type.stage13:
                if (29 <= sum_star)
                {
                    startButton.SetActive(true);
                }
                else
                {
                    text_conditionToStart.text = sum_star + "/29";
                    startButton.SetActive(false);

                }
                break;
            case StageData.Type.stage14:
                if (34 <= sum_star)
                {
                    startButton.SetActive(true);
                }
                else
                {
                    text_conditionToStart.text = sum_star + "/34";
                    startButton.SetActive(false);

                }
                break;
            case StageData.Type.stage15:
                if (42 <= sum_star)
                {
                    startButton.SetActive(true);
                }
                else
                {
                    text_conditionToStart.text = sum_star + "/42";
                    startButton.SetActive(false);

                }
                break;
            default:
                startButton.SetActive(true);
                text_conditionToStart.text = "";
                break;

        }
        star_paper.SetActive(!startButton.activeSelf);
    }

    private int StarSum()
    {
        int starSum = 0;

        foreach (StageClearDate stageClearDate in SavedateInstance.instance.savedate.stageClearDates)
        {
            starSum += stageClearDate.bestclearStar;
        }
        return starSum;
    }
    public void PaperAnima()
    {
        anima_paper.Play("paper");
    }
    public void SetSpawnPointButton()
    {
        RewardAD.instance.ShowRewardedAd();
    }

    public void RestartGameButton()
    {
        
        SavedateInstance.instance.savedate.interstitialGauge+=2;
        SavedateInstance.instance.Save();
        if (SavedateInstance.instance.savedate.interstitialGauge >= 10)
        {

            InterstitialAD.instance.ShowAdandRestartGame();
        }
        else
        {
            RestartGame();
        }
        
    }
    public void StartStageButton()
    {
        AudioSE.instance.UI_decide();
        AudioSE.instance.UI_start();
        
        SavedateInstance.instance.savedate.interstitialGauge+=4;
        SavedateInstance.instance.Save();
        if (SavedateInstance.instance.savedate.interstitialGauge >= 10)
        {
            InterstitialAD.instance.ShowAdandStartGame();

        }
        else
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        AudioBGM.instance.PlayBGM();
        panel_start.SetActive(false);
        SetActiveMap();
        player.SetActive(true);
        panel_game.SetActive(true);
    }
    public void RestartGame()
    {
        AudioSE.instance.UI_start();
        PlayerController.instance.OnEnable();
        TimeController.instance.OnEnable();
        panel_gameMenu.SetActive(false);
        ResetSpawnPoint();

    }

    public void BackToGame()
    {
        panel_respawn.SetActive(false);
        TimeController.instance.NotStopTime();
    }
   
}



