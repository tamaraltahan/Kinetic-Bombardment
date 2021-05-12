using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); //put name of first level here when it is made
        if (SelectMenu.unlocked < 1)
        {
            SelectMenu.unlocked = PlayerPrefs.GetInt("unlocked", 1);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelSelectScreen()
    {
        SceneManager.LoadScene("Level Select"); //put name of level select scene when it is made
    }


    public void AboutScreen()
    {
        SceneManager.LoadScene("About Menu"); //put name of about scene when it is made
    }
}
