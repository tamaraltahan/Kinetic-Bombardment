using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement
;
public class PauseMenu : MonoBehaviour
{
    //This is here so it can be used in other scripts since its public. 
    //If another scipt uses it, it will be affected by the pasuing and unpausing if implemented to do so
    public  bool GameIsPaused = false;

    //Makes it so the pasue menu can actually be affected when the right gameobject is placed back in Unity.
    public GameObject pauseMenuUI;
    
    //Resumes gameplay. Is public so it can be accesed by the button UI.
     public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    } 
    //Used to pasue the game. Keep public to use with buttons
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //Used to switch to the menu but rightnow it only sends a debug message. Need to add the ability to switch scenes later.
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu 1");
    }
    //Will be used to go to the level select. For now it just sends a debug message
    public void LevelSelect()
    {
        Debug.Log("Loading level select...");
    }

}
