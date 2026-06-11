
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    bool hit=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hit)
        {
            if (collision.transform.tag == "Player")
            {
                hit = true;
                //Generator.instance.GenerateExplotion(gameObject.transform.position);
                Destroy(gameObject);
            }
            else if (collision.transform.tag == "OutofArea")
            {
                hit = true;
                Destroy(gameObject);
            }
        }
    }

    
}
