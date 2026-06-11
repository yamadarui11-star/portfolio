
using UnityEngine;

public class InternetReach : MonoBehaviour
{
    [SerializeField] GameObject panel_internetError;
    private void FixedUpdate()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            panel_internetError.SetActive(true);
        }
        else panel_internetError.SetActive(false);
    }
}
