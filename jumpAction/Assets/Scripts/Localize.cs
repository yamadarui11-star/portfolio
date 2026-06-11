using TMPro;
using UnityEngine;

public class Localize : MonoBehaviour
{
    public static Localize instance;
    [SerializeField] TextMeshProUGUI stage;
    [SerializeField] TextMeshProUGUI stage2;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI bestTime;
    [SerializeField] TextMeshProUGUI home;
    [SerializeField] TextMeshProUGUI reset;
    [SerializeField] TextMeshProUGUI start;
    [SerializeField] TextMeshProUGUI respawnQ;
    [SerializeField] TextMeshProUGUI respawn;
    [SerializeField] TextMeshProUGUI setspawn;
    [SerializeField] TextMeshProUGUI internetError;
    [SerializeField] TextMeshProUGUI jump;
    [SerializeField] TextMeshProUGUI jump_guide;
    [SerializeField] TextMeshProUGUI airMovement;
    [SerializeField] TextMeshProUGUI airMovement_guide;
    [SerializeField] TextMeshProUGUI twoStepJump;
    [SerializeField] TextMeshProUGUI twoStepJump_guide;
    [SerializeField] TextMeshProUGUI howTo;


    int languageNum = 0;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        if (Application.systemLanguage == SystemLanguage.Japanese) languageNum = 1;
        else languageNum = 2;
    }
    private void Start()
    {
        LocalizeText();
    }

    public void LocalizeText()
    {
        if (languageNum == 1)
        {
            stage2.text = "ステージ";
            time.text = "タイム";
            stage.text = "ステージ";
            bestTime.text = "ベストタイム";
            home.text = "ホーム";
            reset.text = "リセット";
            start.text = "スタート";
            respawnQ.text = "リスポーンポイントを\nセットしますか?";
            respawn.text = "リスポーンポイントをセットするとセットした場所と時間でリスポーンすることができます。";
            setspawn.text = "セットする";
            internetError.text = "インターネット\n接続エラー";
            jump.text = "ジャンプ";
            jump_guide.text = "画面を長押しするとジャンプすることができます。";
            airMovement.text = "空中移動";
            airMovement_guide.text = "ジャンプ中に画面を左右どちらかの方向にフリックすると横方向に移動することができます。";
            twoStepJump.text = "二段ジャンプ";
            twoStepJump_guide.text = "ジャンプ中にもう一度画面を長押しすると二段ジャンプができます。";
            howTo.text = "操作方法";
        }
        else
        {
            stage2.text = "STAGE";
            time.text = "TIME";
            stage.text = "STAGE";
            bestTime.text = "BEST TIME";
            home.text = "HOME";
            reset.text = "RESET";
            start.text = "START";
            respawnQ.text = "Set a respawn point?";
            respawn.text = "If you set a respawn point, you can respawn at a set location and time.";
            setspawn.text = "Set";
            internetError.text = "Internet connection error";
            jump.text = "Jump";
            jump_guide.text = "Press and hold the screen to jump.";
            airMovement.text = "Air movement";
            airMovement_guide.text = "Flick the screen in either direction while jumping to move horizontally.";
            twoStepJump.text = "two-step jump";
            twoStepJump_guide.text = "If you press and hold the screen again while jumping, you can make a double jump.";
            howTo.text = "HOW TO";
        }
    }

}
