using TMPro;
using UnityEngine;

public class interneterror : MonoBehaviour
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
        text.text = "インターネット接続エラー";

    }

    private void SetEnText()
    {
        text.text = "Internet connection error";

    }
}