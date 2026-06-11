
using UnityEngine;

public class Enemy2 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 8;
        thismass = 50;
        bulletRate = 200;
        bulletSpeed = 5f;
        bulletNum = 2;
        bulletEuler = 90 / (bulletNum + 1);
        animator = gameObject.GetComponent<Animator>();


    }

}
