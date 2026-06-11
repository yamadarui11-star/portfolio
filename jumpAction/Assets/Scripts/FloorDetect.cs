
using UnityEngine;

public class FloorDetect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            PlayerController.instance.OnFloor();
        }
    }
}
