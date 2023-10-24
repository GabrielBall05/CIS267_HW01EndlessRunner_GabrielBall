using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject[] collectables;

    private float collectableSpawnTimer;
    public float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnCollectables();
    }

    public void spawnCollectables()
    {
        //Spawns random collectable at random location every 30 seconds

        //If timer hasn't reached the value of the timer (30s)
        if (collectableSpawnTimer <= timeBetweenSpawns)
        {
            //Increment timer
            collectableSpawnTimer += Time.deltaTime;
        }
        else //It has reached the timer value (30s)
        {
            //Reset
            collectableSpawnTimer = 0;

            //Make new random collectable spawn at random location
            int randomIndexCollectable;
            int randomIndexSpawnLoc;
            GameObject spawnedCollectable;

            randomIndexCollectable = Random.Range(0, collectables.Length);
            randomIndexSpawnLoc = Random.Range(0, spawnLocations.Length);

            spawnedCollectable = Instantiate(collectables[randomIndexCollectable].gameObject);

            spawnedCollectable.transform.position = new Vector2(spawnLocations[randomIndexSpawnLoc].transform.position.x, spawnLocations[randomIndexSpawnLoc].transform.position.y);
        }
    }
}
