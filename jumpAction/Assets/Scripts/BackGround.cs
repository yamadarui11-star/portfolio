
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] float offset_y;
    [SerializeField] float ratio;
    // Start is called before the first frame update
    
    
    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(0, (PlayerController.instance.transform.position.y)/ratio+offset_y, 0);
    }
}
