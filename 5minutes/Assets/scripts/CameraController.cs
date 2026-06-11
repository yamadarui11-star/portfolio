using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public static bool isrotate=false;
    
    void Start()
    {

    }
    public IEnumerator move(Vector3 from, Vector3 to, int FPS)
    {
        for (int i = 0; i < FPS; i++)
        {
            transform.position += (to - from) / FPS;
            yield return new WaitForSeconds(0.01f);
        }

    }

    public IEnumerator Rotatecamera(Vector3 euler,int fps)
    {

        isrotate = true;
        for (int i = 0; i < fps; i++)
        {
            transform.eulerAngles+=((euler) / fps);
            yield return new WaitForSeconds(0.01f);
        }
        isrotate = false;

        yield break;
    }

   
}
