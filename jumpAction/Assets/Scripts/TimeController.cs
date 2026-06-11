using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    [SerializeField] TextMeshProUGUI text_time;
    [System.NonSerialized] public float time;
    bool stopTime;

    public  void OnEnable()
    {
        stopTime = false;
        time = 0;
    }
    private void Isgoal()
    {
        stopTime = true;
    }

    public void StopTime()
    {
        stopTime = true;
    }

    public void NotStopTime()
    {
        stopTime = false;
    }
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
        Director.instance.onGoal += Isgoal;
    }

    private void FixedUpdate()
    {
        if (!stopTime)
        {
            text_time.text = time.ToString("f1");
            time += Time.deltaTime;
        }
    }

}
