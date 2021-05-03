using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    public int unlocked;

    void start()
    {
        unlocked = PlayerPrefs.GetInt("unlocked", 1);
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
