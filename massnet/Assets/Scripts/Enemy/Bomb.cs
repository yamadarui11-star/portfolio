
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rigidbody;
    bool inscreen = false;
    bool isMagneticArea = false;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Magneticarea")
        {
            isMagneticArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Magneticarea")
        {
            isMagneticArea = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
                //Generator.instance.GenerateExplotion(gameObject.transform.position);
                Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        inscreen = true;
    }
    private void OnBecameInvisible()
    {
        inscreen = false;
    }

    

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (inscreen)
        {
            if (isMagneticArea)
            {
                rigidbody.velocity = Director.instance.ToplayerVec(transform.position).normalized * 2;//ˆø—Í

            }
            else
            {
                rigidbody.velocity = new Vector2(0, 0);
            }
           
        }
    }
}
