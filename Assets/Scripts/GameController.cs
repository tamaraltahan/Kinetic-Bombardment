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
    public int numAllAmmo = 0;
    public int AmmoLoader;// make this a public int. That way when you load a new scene you can set this int to whatever you want.  Customizable starting ammo ;)
    // Start is called before the first frame update
    // public int score = 0;
    void Start()
    {
        loadAmmo();
    }
    private void countAmmo()
    {
        int curAmmo = 0;
        for (int i = 0; i < player.weaponsList.Count; ++i)
        {
            curAmmo += player.weaponsList[i].GetComponent<Weapon>().ammo;
        }
        numAllAmmo = curAmmo;
    }
    public void loadAmmo()//you can call this from other scripts to reload your wepapon at the beginning of the scene.
    {
        for (int i = 0; i < player.weaponsList.Count; ++i)
        {
            player.weaponsList[i].GetComponent<Weapon>().ammo = AmmoLoader;
        }
        countAmmo();
    }


    private void countEnemies()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;//count all objects with "enemy" tag
        if (GameObject.FindGameObjectWithTag("Boss")) //set boos boolean if we find an object with the tag
        {
            isBossALive = true;
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
        Debug.Log("Haha idiot loser");
    }

    private void win()
    {
        Debug.Log("Pog");
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
            // postLevelScene.LoadScene(postLevelScene.GetActiveScene().name);
        }
        else if(numAllAmmo <= 0)
        {
            lose();
        }
        //scoreText.text = "Score: " + score.ToString();
    }
    /*
    public void AddScore(int amt)
    {
        score += col;
    }
    */
}
