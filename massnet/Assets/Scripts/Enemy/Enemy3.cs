
using UnityEngine;

public class Enemy3 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 10;
        thismass = 300;
        bulletRate = 400;
        bulletSpeed = 8f;
        bulletNum = 1;
        bulletEuler = 90 / (bulletNum + 1);
        animator = gameObject.GetComponent<Animator>();


    }
}
