using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteController : MonoBehaviour
{
    private Image uiImage;
    private PlayerController player;
    public List<Sprite> spriteList = new List<Sprite>();
    private int prevIndex;

    private void Awake()
    {
        uiImage = GetComponent<Image>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        prevIndex = player.currentIndex;
        Debug.Log("Array size: " + spriteList.Count + "\nPlayer Index: " + player.currentIndex + "\nCurrent Index: " + prevIndex);
    }

    private void ChangeSprite(int index)
    {
        uiImage.sprite = spriteList[index];
    }

    private void Update()
    {
        //only change sprites if the index is different
        if(player.currentIndex != prevIndex)
        {
            Debug.Log("Player's Index: " + player.currentIndex + ", Previous index: " + prevIndex);
            ChangeSprite(player.currentIndex);
            prevIndex = player.currentIndex;
        }
    }


}
