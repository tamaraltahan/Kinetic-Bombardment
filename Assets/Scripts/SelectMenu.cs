using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{

    public static int unlocked;

    void start()
    {
        unlocked = 1;
        //unlocked = PlayerPrefs.GetInt("unlocked", 1);
    }


    void onEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void onDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       /* Button b2 = GameObject.Find("Level 2 Button").getComponent<Button>();
        if (unlocked < 2) b2.interactable = false;
        else button2.interactable = true;*/
    }

    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SelectLevel2()
    {
        if (unlocked >= 2)
        {
            SceneManager.LoadScene("Level2");
        }
        
    }

    public void SelectLevel3()
    {
        if (unlocked >= 3)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    public void SelectLevel4()
    {
        if (unlocked >= 4)
        {
            SceneManager.LoadScene("Level4");
        }
    }

    public void SelectLevel5()
    {
        if (unlocked >= 5)
        {
            SceneManager.LoadScene("Level5");
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main Menu 1");
    }

}
