using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteController : MonoBehaviour
{
    private Image uiImage;
    public PlayerController player;
    public List<Sprite> spriteList = new List<Sprite>();
    private int prevIndex;
    private int playerIndex;

    private void Awake()
    {
        uiImage = GetComponent<Image>();
        prevIndex = player.currentIndex;
    }

    private void ChangeSprite(int index)
    {
        uiImage.sprite = spriteList[index];
    }

    private void Update()
    {
        playerIndex = player.currentIndex;
        //only change sprites if the index is different
        if(playerIndex != prevIndex)
        {
            Debug.Log("Player's Index: " + player.currentIndex + ", Previous index: " + prevIndex);
            ChangeSprite(playerIndex);
            prevIndex = playerIndex;
        }
    }


}
