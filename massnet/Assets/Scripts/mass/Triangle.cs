using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Mass
{

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 0;
        thismass = 1;
        
    }

}
