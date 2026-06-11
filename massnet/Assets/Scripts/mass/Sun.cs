
using UnityEngine;

public class Sun : Mass
{
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        massSize = 25;
        thismass = 300;

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
