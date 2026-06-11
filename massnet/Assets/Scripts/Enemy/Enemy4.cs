
using UnityEngine;

public class Enemy4 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 40;
        thismass = 5000;
        bulletRate = 50;
        bulletSpeed = 8f;
        bulletNum = 1;
        bulletEuler = 90 / (bulletNum + 1);
        animator = gameObject.GetComponent<Animator>();


    }

}
