using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{

    public GameObject spawnObject; //enemy to (re)spawn
    public float spawnCD;
    public int enemyCount;
    public float respawnCD;
    float CDTime;
    // Start is called before the first frame update
    private void Awake()
    {
        CDTime = respawnCD;
    }
    // Update is called once per frame
    // respawn enemy after n seconds
    void Update()
    {
        if (enemyCount <= 0 && CDTime <= 0)
            SpawnEnemy();

        if(enemyCount <= 0) CDTime -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        enemyCount++;
        CDTime = respawnCD;
        GameObject newObj = Instantiate(spawnObject);
        newObj.transform.SetParent(transform);
        newObj.transform.position = transform.position;
    }
}
