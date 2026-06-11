using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip touchbuttonSE;
    public AudioClip touchtrashcanbuttonSE;
    public AudioClip clearbuttonSE;
    public AudioClip openSE;
    public AudioClip closeSE;
    public AudioClip unlockSE;
    public AudioClip openfridge;
    public AudioClip closefridge;
    public AudioClip menubutton;
    public AudioClip pourwater;
    public AudioClip slidebutton;
    public AudioClip drawer;
    public AudioClip selectslot;
    public AudioClip cancel;
    public AudioClip getitem;
    public AudioClip cancel1;
    public AudioClip decision;
    public AudioClip knife;
    public AudioClip addnabe;
    public AudioClip remocon;
    public AudioClip putflower;
    public AudioClip unlock;
    public AudioClip lighter;
    public AudioClip touchpanelbutton;
    public AudioClip addwater;
    public AudioClip decide;
  
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void TouchfoodbuttonSE()
    {
        audioSource.PlayOneShot(touchbuttonSE);
    }
    public void TouchtrashcanbuttonSE()
    {
        audioSource.PlayOneShot(touchtrashcanbuttonSE);
    }

    public void ClearSE()
    {
        audioSource.PlayOneShot(clearbuttonSE);
    }

    public void PlayopenSE()
    {
        audioSource.PlayOneShot(openSE);
    }
    public void PlaycloseSE()
    {
        audioSource.PlayOneShot(closeSE);
    }

    public void PlayunlockSE()
    {
        audioSource.PlayOneShot(unlockSE);
    }
    public void Openfridge()
    {
        audioSource.PlayOneShot(openfridge);
    }
    public void Closefridge()
    {
        audioSource.PlayOneShot(closefridge);
    }
    public void Touchmenu()
    {
        audioSource.PlayOneShot(menubutton);
    }
    public void Pourwater()
    {
        audioSource.PlayOneShot(pourwater);
    }
    public void Slidebutton()
    {
        audioSource.PlayOneShot(slidebutton);
    }
    public void Drawer()
    {
        audioSource.PlayOneShot(drawer);
    }
    public void Selectslot()
    {
        audioSource.PlayOneShot(selectslot);
    }
    public void Cancel1()
    {
        audioSource.PlayOneShot(cancel1);
    }
    public void Getitem()
    {
        audioSource.PlayOneShot(getitem);
    }
    public void Cancel()
    {
        audioSource.PlayOneShot(cancel);
    }
    public void Decision()
    {
        audioSource.PlayOneShot(decision);
    }
    public void Knife()
    {
        audioSource.PlayOneShot(knife);
    }
    public void Addnabe()
    {
        audioSource.PlayOneShot(addnabe);
    }
    public void Remocon()
    {
        audioSource.PlayOneShot(remocon);
    }
    public void Putflower()
    {
        audioSource.PlayOneShot(putflower);
    }
    public void Unlock()
    {
        audioSource.PlayOneShot(unlock);
    }
    public void Lighter()
    {
        audioSource.PlayOneShot(lighter);
    }

    public void Touchpanelbutton()
    {
        audioSource.PlayOneShot(touchpanelbutton);
    }

    public void Addwater()
    {
        audioSource.PlayOneShot(addwater);
    }
    public void Decide()
    {
        audioSource.PlayOneShot(decide);
    }
}
