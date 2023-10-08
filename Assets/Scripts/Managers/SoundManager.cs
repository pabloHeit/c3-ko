using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InitMusic();
    }

    public void InitMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }


    public void OnShotHitSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);

    }
}
