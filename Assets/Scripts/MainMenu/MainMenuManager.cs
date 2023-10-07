using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void StartGameEvent()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    public void ExitGameEvent()
    {
        Application.Quit();
    }

}
