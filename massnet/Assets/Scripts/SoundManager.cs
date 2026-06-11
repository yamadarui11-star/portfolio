using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource audioSource;

    public enum audioClips_type
    {
        getmass,
        button,
        cancel,
        levelup,
        play,
        slide,
        pi,
    }
    [SerializeField] AudioClip clip_getmass;
    [SerializeField] AudioClip clip_button;
    [SerializeField] AudioClip clip_cancel;
    [SerializeField] AudioClip clip_levelup;
    [SerializeField] AudioClip clip_play;
    [SerializeField] AudioClip clip_slide;
    [SerializeField] AudioClip clip_pi;



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
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySE(audioClips_type audioClip)
    {
        switch (audioClip)
        {
            case audioClips_type.getmass:
                PlayOneShot(clip_getmass);
                break;
            case audioClips_type.button:
                PlayOneShot(clip_button);
                break;
            case audioClips_type.cancel:
                PlayOneShot(clip_cancel);
                break;
            case audioClips_type.levelup:
                PlayOneShot(clip_levelup);
                break;
            case audioClips_type.play:
                PlayOneShot(clip_play);
                break;
            case audioClips_type.slide:
                PlayOneShot(clip_slide);
                break;
            case audioClips_type.pi:
                PlayOneShot(clip_pi);
                break;
        }
    }
    private void PlayOneShot(AudioClip audioclip)
    {
        audioSource.PlayOneShot(audioclip);
    }
}
