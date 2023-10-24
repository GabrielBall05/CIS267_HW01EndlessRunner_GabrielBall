using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject enemy;
    private float timer = 0f;
    public float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        //===
        //Spawn one in to start off with
        int randomIndex;
        randomIndex = Random.Range(0, spawnLocations.Length);

        Instantiate(enemy.gameObject);

        enemy.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        //===
    }

    // Update is called once per frame
    void Update()
    {
        spawnBasicEnemies();
    }

    public void spawnBasicEnemies()
    {
        //Waits "timeBetweenSpawns" seconds then spawns basic enemy. Will do forever
        if (timer <= timeBetweenSpawns)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //Reset
            timer = 0f;

            //Spawns enemy in at random spawn location
            int randomIndex;
            randomIndex = Random.Range(0, spawnLocations.Length);

            Instantiate(enemy.gameObject);

            enemy.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        }
    }

    public void setTimeBetweenSpawns(float t)
    {
        timeBetweenSpawns = t;
    }
}
