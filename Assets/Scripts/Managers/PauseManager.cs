using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private AudioSource _music;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            TogglePause();
        }
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        _pauseScreen.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0 : 1;

        //print("Tocado el scape");

        if(_music.time <= 0.1f)
        {
            return;
        }

        if (_isPaused)
        {
            _music.Pause();
        }
        else
        {
            _music.Play();
        }

    }
}
