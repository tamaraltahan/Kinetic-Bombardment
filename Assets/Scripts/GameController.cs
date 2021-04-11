using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int numEnemies;
    bool isBossALive = false;
    PauseMenu pauser;

    public PlayerController player;
    public int numAllAmmo = 0;
    public int AmmoLoader;// make this a public int. That way when you load a new scene you can set this int to whatever you want.  Customizable starting ammo ;)
    public List<int> ammoLoadList = new List<int>();

    public GameObject winScreen; // used to make the win screen accesable
    public GameObject loseScreen; // used to make the lose screen accesable

    public Text ammocountone;
    public Sprite ammoui;

    private bool isMouseOnUI = false;

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
            //player.weaponsList[i].GetComponent<Weapon>().ammo = AmmoLoader;
            player.weaponsList[i].GetComponent<Weapon>().ammo = ammoLoadList[i];
        }
        //ammocountone.text = player.weaponsList[0].GetComponent<Weapon>().ammo.ToString();
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

    //gotta get some scene managemenet here
    private void lose()
    {
        loseScreen.SetActive(true);
        Debug.Log("Haha idiot loser");
    }

    private void win()
    {
        winScreen.SetActive(true);
        Debug.Log("Pog");
    }
        

    // Update is called once per frame
    void Update()
    {
        //Press 'p' to pause
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
            Weapon finalBullet = FindObjectOfType<Weapon>(); ;
            if(finalBullet == null && numEnemies > 0)
            lose();
        }
        //scoreText.text = "Score: " + score.ToString();
    }

    //using these two public functions in UI scripts to centralize the detection process.
    public void mouseOnUI()
    {
        isMouseOnUI = true;
    }
    public void mouseNotOnUI()
    {
        isMouseOnUI = false;
    }

    public bool evalMouse()
    {
        return isMouseOnUI;
    }


    /*
    public void AddScore(int amt)
    {
        score += col;
    }
    */
}
