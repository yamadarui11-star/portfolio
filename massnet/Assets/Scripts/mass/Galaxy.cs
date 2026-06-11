
using UnityEngine;

public class Galaxy : Mass
{
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 35;
        thismass = 1000;

    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.transform.tag == "Magneticarea")
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
}
