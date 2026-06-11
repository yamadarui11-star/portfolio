using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    public static canvas canvasinstance;
    private void Awake()
    {
        single();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void single()
    {
        if (canvasinstance == null)
        {
            canvasinstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
