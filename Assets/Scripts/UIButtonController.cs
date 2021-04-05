using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonController : MonoBehaviour
{
    public GameObject UIParent;
    GameController controller;

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        UIParent.SetActive(false);
        Time.timeScale = 1f;
        controller.mouseNotOnUI();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            controller.mouseOnUI();
        }
        else
        {
            controller.mouseNotOnUI();
        }
    }


}
