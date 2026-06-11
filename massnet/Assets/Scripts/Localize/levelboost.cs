using TMPro;
using UnityEngine;

public class levelboost : MonoBehaviour
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
        text.text = "レベル\nブースト";

    }

    private void SetEnText()
    {
        text.text = "Boost\nlevel";
    }
}

