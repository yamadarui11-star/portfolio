
using UnityEngine;

public class Rock_gold : Mass
{
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 12;
        thismass = 20;

    }
}
