
using UnityEngine;


public class InputTouch : MonoBehaviour
{
    public static InputTouch instance;
    bool buttonisDowning=false;
    Vector2 mousedownPos;
    Vector2 moveVector;
    [SerializeField]
    Rigidbody2D rigidbody;
    bool timeUp = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
    }
    public void TimeUp()
    {
        timeUp = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            Debug.Log("hit");
        }
    }
    private void Update()
    {
        if (!timeUp)
        {
            if (buttonisDowning)
            {
                moveVector = ((Vector2)Input.mousePosition - mousedownPos).normalized;
                rigidbody.velocity = moveVector * Director.instance.playerSpeed;
                if (Input.GetMouseButtonUp(0))
                {
                    buttonisDowning = false;
                    rigidbody.velocity = new Vector2(0, 0);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    buttonisDowning = true;
                    mousedownPos = Input.mousePosition;
                }
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(0, 0);
        }
    }
}
