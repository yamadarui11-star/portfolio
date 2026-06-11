
using UnityEngine;

public class Rock_red : Mass
{
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 6;
        thismass = 6;

    }
}
