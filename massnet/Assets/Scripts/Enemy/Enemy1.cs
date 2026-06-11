
using UnityEngine;

public class Enemy1 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 5;
        thismass = 10;
        bulletRate = 100;
        bulletSpeed = 3.5f;
        bulletNum = 1;
        bulletEuler = 90 / (bulletNum + 1);
        animator = gameObject.GetComponent<Animator>();

    }

}
