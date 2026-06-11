using System.Collections;
using UnityEngine;

public class AudioBGM : MonoBehaviour
{
    public static AudioBGM instance;
    [SerializeField] AudioSource audio;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        Director.instance.onGoal += FadeOutBGM;
        Director.instance.onStartScreen += audio.Stop;
    }

    public void PlayBGM()
    {
        audio.volume = 0.5f;
        audio.Stop();
        audio.Play();
    }

    public void FadeOutBGM()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        while (audio.volume > 0)
        {
            audio.volume -= 0.05f;
            
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void MuteBGM()
    {
        audio.mute = true;
    }
    public void NotMuteBGM()
    {
        audio.mute = false;
    }
}
