
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Director : MonoBehaviour
{
    public static Director instance;
    public GameObject player;
    [SerializeField] TextMeshProUGUI massScoreText;
    [SerializeField] CircleCollider2D magneticArea;
    [SerializeField] float time = 10.0f;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject scorePanel;
    [SerializeField] TextMeshProUGUI text_result_selectedstage;
    float rndx;
    float rndy;
    bool onoff;
    bool stopFixedupdate = false;
    bool isRed=false;
    bool isBoosting = false;
    public event System.Action OnMassScoreUp;
    public event System.Action OnTimeUp;
    public event System.Action OnStartGame;
    public event System.Action OnMassScoreDown;
    float defaultMagneticRad = 0.7f;
    [System.NonSerialized]
    public int generatednum = 0;
    [System.NonSerialized]
    public int massScore = 0;
    [System.NonSerialized]
    public int nowfase =1;
    public float playersize;
    public float playerSpeed;
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
        CheckBoosting();
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        OnStartGame += UpdateMassScoreText;
        OnStartGame += UpdateSize;
        OnStartGame += UpdatePlayerSpeed;
        OnMassScoreUp += UpdateMassScoreText;
        OnMassScoreDown += UpdateMassScoreText;
        OnTimeUp += InputTouch.instance.TimeUp;
        OnTimeUp += ShowScorePanel;
        OnTimeUp += SaveMassScore;
        OnTimeUp += UpdateUI;
        OnStartGame.Invoke();
    }

    private void CheckBoosting()
    {
        if (SavedataInstance.instance.savedata.boostTime > 0)
        {
            SavedataInstance.instance.savedata.boostTime--;
            SavedataInstance.instance.Save();
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }
    }
    private void UpdateUI()
    {
        text_result_selectedstage.text = "Stage"+SavedataInstance.instance.savedata.selectedStage.ToString();
    }
    private void SaveMassScore()
    {
        SavedataInstance.instance.Save();
    }
    private void ShowScorePanel()
    {
        scorePanel.SetActive(true);
    }
    public Vector2 ToplayerVec(Vector2 from)
    {
        return (Vector2)player.transform.position - from;
    }
    
    private void UpdateMassScoreText()
    {
        massScoreText.text = SavedataInstance.instance.savedata.ownMassScore.ToString();
    }
    public void InvokeOnMassScoreUp(int score)
    {
        massScore += score;
        SavedataInstance.instance.savedata.ownMassScore += score;
        Generator.instance.GenerateScoreupText(score);
        OnMassScoreUp.Invoke();
        Generator.instance.GenerateMagneticCircle();
        SoundManager.instance.PlaySE(SoundManager.audioClips_type.getmass);
        Vibration.ShortVibration();
    }

    public void InvokeOnMassScoreDown(int score)
    {
        massScore -= score;
        SavedataInstance.instance.savedata.ownMassScore -= score;
        OnMassScoreDown.Invoke();
    }
    private void UpdateSize()
    {
        if (isBoosting)
        {
            playersize = SavedataInstance.instance.savedata.playerSize_Level + 10;
            Camera.main.orthographicSize = ((playersize - 1) * 0.3f) + 5;
            magneticArea.radius = defaultMagneticRad + ((playersize - 1) * 0.3f) * 0.2f;
        }
        else
        {
            playersize = SavedataInstance.instance.savedata.playerSize_Level ;
            Camera.main.orthographicSize = (playersize - 1) * 0.3f + 5;
            magneticArea.radius = defaultMagneticRad + ((playersize - 1) * 0.3f) * 0.2f;
        }
    }

    private void UpdatePlayerSpeed()
    {
        if (isBoosting)
        {
            playerSpeed = (SavedataInstance.instance.savedata.playerSpeed_Level+10 - 1) * 0.3f + 2;

        }
        else
        {
            playerSpeed = (SavedataInstance.instance.savedata.playerSpeed_Level - 1) * 0.3f + 2;

        }
    }
    public Vector2 GenerateRandomPos()
    {
        rndx = Random.Range(-100,100);
        rndy = Randomy(rndx);
        return new Vector2(rndx, rndy);
    }
    private Vector2 UpperRightScreenPoint(float ratio)
    {
        return new Vector2(Screen.width* ratio, Screen.height*ratio);
    }

    private Vector2 LowerLeftScreenPoint(float ratio)
    {
        return new Vector2((1 - ratio) * Screen.width, (1 - ratio) * Screen.height);
    }

    private float Randomy(float rndx)
    {
        if (rndx <= Camera.main.ScreenToWorldPoint(UpperRightScreenPoint(1)).x && rndx >= Camera.main.ScreenToWorldPoint(LowerLeftScreenPoint(1)).x)//xÇ™âÊñ ì‡Ç»ÇÁ
        {
            if (onoff)
            {
                onoff = false;
                return Random.Range(Camera.main.ScreenToWorldPoint(UpperRightScreenPoint(1)).y, 100);//âÊñ äOè„
            }
            else
            {
                onoff = true;
                return Random.Range(Camera.main.ScreenToWorldPoint(LowerLeftScreenPoint(1)).y, -100);//âÊñ äOâ∫
            }
        }
        else
        {
            return Random.Range(-100,100);
        }
    }
    private void FixedUpdate()
    {
        

        if (time <= 0)
        {
            if (!stopFixedupdate)
            {
                time = 0;
                OnTimeUp.Invoke();
                stopFixedupdate = true;
            }
        }
        else
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("f1");
        }
        if (!isRed && time <= 10)
        {
            timeText.color = Color.red;
            isRed = true;
        }

    }
}
