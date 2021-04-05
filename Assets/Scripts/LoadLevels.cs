using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    GameController controller;
    //These are going to be used to load the level scenes
    public void Level1() // Loads Level 1
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2() // loads level 2
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3() // loads level 3
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level4() // loads level 4
    {
        SceneManager.LoadScene("Level4");
    }

    public void Reloadlevel()// This should be used to reload the current level so the player can retry
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}

