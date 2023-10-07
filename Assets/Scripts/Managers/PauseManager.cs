using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = _isPaused ? 1 : 0;
            _isPaused = !_isPaused;

            print("Tocado el scape");
        }

    }
}
