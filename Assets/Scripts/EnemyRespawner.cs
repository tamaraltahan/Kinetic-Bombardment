using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{

    public GameObject spawnObject; //enemy to (re)spawn
    public float spawnCD;
    // Start is called before the first frame update

    // Update is called once per frame
    // respawn enemy after n seconds
    void Update()
    {
        if(transform.childCount == 0)
            Invoke("SpawnEnemy", spawnCD);

        if (transform.childCount > 0)
            CancelInvoke();

    }

    void SpawnEnemy()
    {
        GameObject newObj = Instantiate(spawnObject);
        newObj.transform.SetParent(transform);
        newObj.transform.position = transform.position;
    }
}
