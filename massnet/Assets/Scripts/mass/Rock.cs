
using UnityEngine;

public class Rock : Mass
{
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 3;
        thismass = 2;

    }
}
