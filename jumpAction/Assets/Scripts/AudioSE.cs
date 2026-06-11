using UnityEngine;

public class AudioSE : MonoBehaviour
{
    public static AudioSE instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip ui_decide;
    [SerializeField] AudioClip ui_cancel;
    [SerializeField] AudioClip ground;
    [SerializeField] AudioClip result;
    [SerializeField] AudioClip ui_start;
    [SerializeField] AudioClip starA;
    [SerializeField] AudioClip starB;
    [SerializeField] AudioClip starC;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    
    public void Jump()
    {
        PlaySound(jump);
    }

    public void UI_decide()
    {
        PlaySound(ui_decide);
    }
    public void UI_cancel()
    {
        PlaySound(ui_cancel);
    }
    public void Ground()
    {
        PlaySound(ground);
    }
    public void Result()
    {
        PlaySound(result);
    }
    public void UI_start()
    {
        PlaySound(ui_start);
    }
    public void PianoA()
    {
        PlaySound(starA);

    }
    public void PianoB()
    {
        PlaySound(starB);

    }
    public void PianoC()
    {
        PlaySound(starC);

    }
}
