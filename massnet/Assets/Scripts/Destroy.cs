
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyOwn()
    {
        
        Destroy(gameObject);
    }
}
