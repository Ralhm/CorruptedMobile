using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    public AudioSource AudioSource;


    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    public void PlaySFX(AudioClip SFX)
    {
        AudioSource.PlayOneShot(SFX);
    }


}
