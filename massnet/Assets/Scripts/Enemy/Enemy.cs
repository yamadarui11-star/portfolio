
using UnityEngine;

public class Enemy : Mass
{
    protected Animator animator;
    protected int bulletRate;
    protected float bulletSpeed;
    protected int bulletNum;
    protected float bulletEuler;
    int time = 0;
    Vector2 toPlayerVec;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        bulletEuler = 90 / (bulletNum + 1);
    }
    protected  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Magneticarea")
        {
            isMagneticArea = true;
            CompareMassSizeandPlayerSize();
            if (isLargerthanPlayerMass)
            {
                transform.tag = "Player";
                Director.instance.massScore += thismass;
                Director.instance.InvokeOnMassScoreUp(thismass);
            }
        }
    }


    private void FixedUpdate()
    {
        time += 1;
        toPlayerVec = Director.instance.ToplayerVec(transform.position);
        if (isLargerthanPlayerMass)
        {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;

            if (isMagneticArea)
            {
                rigidbody.velocity = (toPlayerVec.normalized * Director.instance.playerSpeed*1.2f);//ˆø—Í

            }
            else
            {
                rigidbody.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        if (transform.tag != "Player")
        {
            transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(toPlayerVec.x, toPlayerVec.y) * Mathf.Rad2Deg+90);
            if (time % bulletRate == 0)
            {
                animator.SetTrigger("attackTrigger");

                for (int i = 1; bulletNum >= i; i++)
                {
                    Generator.instance.GenerateEnemyBullet(gameObject.transform.position, Quaternion.Euler(0, 0, (i * bulletEuler) - 45) * toPlayerVec, bulletSpeed);
                }
            }
        }

    }

}
