using TMPro;
using UnityEngine;

public class asklevelup : MonoBehaviour
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
        text.text = "ƒŒƒxƒ‹‚ğã‚°‚Ü‚·‚©H";

    }

    private void SetEnText()
    {
        text.text = "Do you want to raise the level?";

    }
}