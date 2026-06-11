using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpstext : MonoBehaviour
{
    float fps;
    TMPro.TextMeshProUGUI textMeshPro;
    void Start()
    {
        
        textMeshPro =gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        fps = 1f / Time.deltaTime;
        textMeshPro.text = fps.ToString();
    }
}
