using TMPro;
using UnityEngine;

public class boosting : MonoBehaviour
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
        text.text = "ブースト中!";

    }

    private void SetEnText()
    {
        text.text = "Boosting!";

    }
}