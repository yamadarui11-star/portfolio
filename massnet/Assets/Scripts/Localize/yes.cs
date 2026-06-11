using TMPro;
using UnityEngine;

public class yes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI yes_text;

    // Start is called before the first frame update
    private void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Japanese) SetJapText();
        else SetEnText();
    }

    private void SetJapText()
    {
        yes_text.text = "‚Í‚¢";
        
    }

    private void SetEnText()
    {

        yes_text.text = "yes";
    }
}
