using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    AudioSource audioSource;
    private float _playTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        print(audioSource.time);
        //audioSource.clip = backgroundMusic;
        _playTime = audioSource.time;

    }

    public void SelectSong(AudioClip song)
    {
        audioSource.clip = song;
    }

    public void InitMusic()
    {
        audioSource.Play();
    }

    public float GetPlayTime()
    {
        //_playTime = audioSource.time;
        return _playTime;
    }


    public void OnShotHitSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);

    }
}
