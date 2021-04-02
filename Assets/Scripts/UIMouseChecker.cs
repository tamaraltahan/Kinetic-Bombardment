using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMouseChecker : MonoBehaviour
{
    public GameController controller;
    // Update is called once per frame
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("poo poo pee pee");
            controller.mouseOnUI();
        }
        else
        {
            Debug.Log("I don't think it's getting here");
            controller.mouseNotOnUI();
        }
    }
}
