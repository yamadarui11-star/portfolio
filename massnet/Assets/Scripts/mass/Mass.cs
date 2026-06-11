
using UnityEngine;

public class Mass : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    protected bool inscreen = false;
    protected bool isMagneticArea=false;
    protected bool isLargerthanPlayerMass=false;
    protected float massSize;
    protected int thismass;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    protected void CompareMassSizeandPlayerSize()
    {
        if (Director.instance.playersize >= massSize)
        {
            isLargerthanPlayerMass = true;
        }
        else
        {
            isLargerthanPlayerMass = false;

        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bomb")
        {
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Magneticarea")
        {
            isMagneticArea = true;
            CompareMassSizeandPlayerSize();
            if (isLargerthanPlayerMass)
            {
                gameObject.transform.tag = "Player";
                Director.instance.InvokeOnMassScoreUp(thismass);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isLargerthanPlayerMass)
        {
            if (collision.transform.tag == "Magneticarea")
            {
                gameObject.transform.tag = "Mass";

                isMagneticArea = false;
                Director.instance.InvokeOnMassScoreDown(thismass);

            }
        }
        
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
    protected void FixedUpdate()
    {
        if (inscreen)
        {
            if (isLargerthanPlayerMass)
            {
                rigidbody.bodyType = RigidbodyType2D.Dynamic;

                if (isMagneticArea)
                {
                    rigidbody.velocity = (Director.instance.ToplayerVec(transform.position).normalized *Director.instance.playerSpeed*1.2f);//ˆø—Í

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

        }
    }
}
