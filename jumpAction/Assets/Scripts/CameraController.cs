
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [SerializeField] float offset_y;
    public  bool followPlayer = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (followPlayer)
        {
            gameObject.transform.position = new Vector3(0, (PlayerController.instance.transform.position.y + offset_y), -10);

        }
    }
}
