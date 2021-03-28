using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void SelectLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main Menu 1");
    }

}
