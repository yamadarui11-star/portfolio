using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = SavedataInstance.instance.savedata.ownMassScore.ToString();
    }

}
