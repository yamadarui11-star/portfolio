
using UnityEngine;

public class Rock_dia : Mass
{
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 12;
        thismass = 100;

    }
}
