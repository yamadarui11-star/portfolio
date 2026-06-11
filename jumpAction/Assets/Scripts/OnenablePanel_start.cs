
using UnityEngine;

public class OnenablePanel_start : MonoBehaviour
{
    private void OnEnable()
    {
        Director.instance.InvokeOnStartScreen();
    }
}
