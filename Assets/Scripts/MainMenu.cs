using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(""); //put name of first level here when it is made
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelSelectScreen()
    {
        SceneManager.LoadScene(""); //put name of level select scene when it is made
    }


    public void AboutScreen()
    {
        SceneManager.LoadScene(""); //put name of about scene when it is made
    }
}
