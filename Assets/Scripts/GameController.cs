using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int numEnemies;
    bool isBossALive = false;
    public Text ammoText; //for telling you that you're out of ammo
    PauseMenu pauser;


    public PlayerController player;
    int numAllAmmo = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < player.weaponsList.Count; ++i)
        {
            int curAmmo = player.weaponsList[i].GetComponent<Weapon>().ammo;
            numAllAmmo += curAmmo;
        }
        loadAmmo();
    }

    private void countEnemies()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;//count all objects with "enemy" tag
        if (GameObject.FindGameObjectWithTag("Boss")) //set boos boolean if we find an object with the tag
        {
            isBossALive = true;
        }
    }

    void loadAmmo()
    {
        for(int i = 0; i < player.weaponsList.Count; ++i)
        {
            player.weaponsList[i].GetComponent<Weapon>().ammo = 10;
        }
    }

    //shows the displayed text for a few seconds, then dissapears
    public void noAmmo()
    {
        StartCoroutine("ShowMessage");
    }

    private IEnumerable ShowMessage()
    {
        ammoText.text = "Out of ammo!";
        ammoText.enabled = true;
        yield return new WaitForSeconds(3f);
        ammoText.enabled = false;
    }

    //gotta get some scene managemenet here
    private void lose()
    {
        Debug.Log("Pog");
    }

    private void win()
    {
        Debug.Log("Haha idiot loser");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pauser.GameIsPaused)
                pauser.Pause();
            else
                pauser.Resume();
        }
        countEnemies();

        //win and lose conditions
        if(numEnemies <= 0 && !isBossALive)
        {
            win();
        }
        else if(numAllAmmo <= 0)
        {
            lose();
        }
        

    }
}
