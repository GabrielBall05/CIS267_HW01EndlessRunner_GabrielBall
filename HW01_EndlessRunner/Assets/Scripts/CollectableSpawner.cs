using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject[] collectables;
    //public GameObject Nuke;
    //public GameObject TimeSlow;
    //public GameObject RapidFire;
    //private float nukeTimer = 0f;
    //private float timeSlowTimer = 0f;
    //private float rapidFireTimer = 0f;
    private float collectableSpawnTimer;
    public float timeBetweenCollectableSpawns;
    ////Time between spawns for Nuke (90s)
    //private float timeBetweenNukeSpawns;
    ////Time between spawns for TimeSlow (60s)
    //private float timeBetweenTimeSlowSpawns;
    ////Time between spawns for RapidFire (45s)
    //private float timeBetweenRapidFireSpawns;

    // Start is called before the first frame update
    void Start()
    {
        //timeBetweenNukeSpawns = 90f;
        //timeBetweenTimeSlowSpawns = 60f;
        //timeBetweenRapidFireSpawns = 45f;

        //I won't start off with any collectables
    }

    // Update is called once per frame
    void Update()
    {
        spawnCollectables();
    }

    public void spawnCollectables()
    {
        //Spawns random collectable at random location every 30 seconds
        if (collectableSpawnTimer <= timeBetweenCollectableSpawns)
        {
            collectableSpawnTimer += Time.deltaTime;
        }
        else
        {
            collectableSpawnTimer = 0;

            int randomIndexCollectable;
            int randomIndexSpawnLoc;
            GameObject spawnedCollectable;

            randomIndexCollectable = Random.Range(0, collectables.Length);
            randomIndexSpawnLoc = Random.Range(0, spawnLocations.Length);

            spawnedCollectable = Instantiate(collectables[randomIndexCollectable].gameObject);

            spawnedCollectable.transform.position = new Vector2(spawnLocations[randomIndexSpawnLoc].transform.position.x, spawnLocations[randomIndexSpawnLoc].transform.position.y);
        }




        ////Waits 90 seconds to spawn Nuke
        //if (nukeTimer <= timeBetweenNukeSpawns)
        //{
        //    nukeTimer += Time.deltaTime;
        //}
        //else
        //{
        //    nukeTimer = 0f;

        //    int randomIndex;
        //    randomIndex = Random.Range(0, spawnLocations.Length);

        //    Instantiate(Nuke.gameObject);

        //    Nuke.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        //}

        ////Waits 60 seconds to spawn TimeSlow
        //if (timeSlowTimer <= timeBetweenTimeSlowSpawns)
        //{
        //    timeSlowTimer += Time.deltaTime;
        //}
        //else
        //{
        //    timeSlowTimer = 0f;

        //    int randomIndex;
        //    randomIndex = Random.Range(0, spawnLocations.Length);

        //    Instantiate(TimeSlow.gameObject);

        //    TimeSlow.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        //}

        ////Waits 45 seconds to spawn RapidFire
        //if (rapidFireTimer <= timeBetweenRapidFireSpawns)
        //{
        //    rapidFireTimer += Time.deltaTime;
        //}
        //else
        //{
        //    rapidFireTimer = 0f;

        //    int randomIndex;
        //    randomIndex = Random.Range(0, spawnLocations.Length);

        //    Instantiate(RapidFire.gameObject);

        //    RapidFire.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        //}
    }
}
