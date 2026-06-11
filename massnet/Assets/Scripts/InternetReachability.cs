using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetReachability : MonoBehaviour
{
    [SerializeField] GameObject panel_Internet;
    private void FixedUpdate()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            panel_Internet.SetActive(true);
        }
        else
        {
            panel_Internet.SetActive(false);

        }
    }
}
