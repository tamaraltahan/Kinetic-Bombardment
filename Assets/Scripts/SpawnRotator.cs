using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRotator : MonoBehaviour
{
    public GameObject sineShot;

    [SerializeField]
    Transform spawnPos;

    [SerializeField]
    PlayerController player;

    [SerializeField]
    int thisIndex;

    [SerializeField]
    bool change = false;

    void Awake()
    {
        spawnPos = GameObject.Find("SpawnPt").transform;
        player = FindObjectOfType<PlayerController>();
        thisIndex = player.currentIndex;
    }



    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.spawnPos.position, this.transform.right, Color.cyan,0.01f,false);
        DoStuff();
    }

    private void DoStuff()
    {
        //int playerIndex = player.currentIndex;
        //Debug.Log(playerIndex);

        if (thisIndex != player.currentIndex) //if weapon is changed
        {
            change = true; //flag it
            thisIndex = player.currentIndex; //change active index

            if (player.currentWeapon == sineShot && change) //if it's the sine shot and we're flagged for change
            {
                Debug.Log("Sine shot active");

                spawnPos.localRotation = Quaternion.Euler(0, 0, -90); //rotate the spawner
                change = false; //mark change as complete
            }
            else if (player.currentWeapon != sineShot && change)
            {
                Debug.Log("Other weapon active");
                spawnPos.localRotation = Quaternion.Euler(0, 0, 0);
                change = false;
            }

        }

    }
}
