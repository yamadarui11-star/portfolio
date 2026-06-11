using TMPro;
using UnityEngine;

public class askwatchAD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    private void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Japanese) SetJapText();
        else SetEnText();
    }

    private void SetJapText()
    {
        text.text = "動画広告を視聴すると3プレイに限りサイズレベル+10とスピードレベル+10の報酬が得られます。\n\n広告を視聴しますか？";

    }

    private void SetEnText()
    {
        text.text = "Viewing video ads rewards size level +10 and speed level +10 for 3 plays only.\n\nWould you like to watch the ad ? ";

    }
}