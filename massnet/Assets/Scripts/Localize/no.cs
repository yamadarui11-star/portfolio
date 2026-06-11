using TMPro;
using UnityEngine;

public class no : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI no_text;

    // Start is called before the first frame update
    private void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Japanese) SetJapText();
        else SetEnText();
    }

    private void SetJapText()
    {
        no_text.text = "‚¢‚¢‚¦";

    }

    private void SetEnText()
    {

        no_text.text = "no";
    }
}
