
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    int jumpNum;
    int swipeNum;
    float swipeSpeed;
    [SerializeField] float maxSwipeSpeed;
    [SerializeField] float minSwipeSpeed;
    [SerializeField] float charaSpeed;
    [SerializeField] Animator playerAnima;
    public new Rigidbody2D rigidbody;
    bool isOnfloor=false;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        Director.instance.onGoal += IsnotSimulate;
    }
    public  void OnEnable()
    {
        rigidbody.simulated = true;
        transform.position = default;
        CameraController.instance.followPlayer = true;
    }

    private void OnDisable()
    {
        CameraController.instance.followPlayer = false;
    }

    private void IsnotSimulate()
    {
        rigidbody.simulated = false;
    }
    public void OnFloor()
    {
        isOnfloor = true;
        jumpNum = 0;
        swipeNum = 0;
        playerAnima.Play("human_idle");
        AudioSE.instance.Ground();
    }

    public  void Jump()
    {
        if (jumpNum == 0 || jumpNum == 1)
        {
            rigidbody.velocity = Vector2.up * charaSpeed;
            jumpNum++;
            swipeSpeed = 0;
            playerAnima.Play("human_jump",0,0);
            AudioSE.instance.Jump();
            isOnfloor = false;
            Vibration.ShortVibration();
        }
    }
    public void SetSwipeSpeed()
    {
        swipeSpeed = Input.GetAxis("Mouse X") * charaSpeed * 0.05f;
    }
    public  void Swipe()
    {
        if (!isOnfloor)
        {
            if (swipeNum == 0 || swipeNum == 1)
            {
                if (swipeSpeed < -maxSwipeSpeed) swipeSpeed = -maxSwipeSpeed;
                else if (maxSwipeSpeed < swipeSpeed) swipeSpeed = maxSwipeSpeed;

                if (swipeSpeed < -minSwipeSpeed || minSwipeSpeed < swipeSpeed)
                {
                    rigidbody.velocity = new Vector2(swipeSpeed, rigidbody.velocity.y);
                    playerAnima.Play("human_swipe");
                }

                swipeNum++;



                if (swipeSpeed < 0 && transform.localScale.x < 0) transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);//スワイプ方向とプレイヤーの向きの調整
                else if (0 < swipeSpeed && 0 < transform.localScale.x) transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

            }

        }
    }
}
