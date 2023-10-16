using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject enemy;
    private float timer = 0f;
    //Start value: 5, Getter and Setter to change via time slow collectable (double the value)
    public float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        //Automatic 5 seconds between spawns
        timeBetweenSpawns = 5f;

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
        //Waits 5 seconds then spawns basic enemy. Will do forever
        if (timer <= timeBetweenSpawns)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;

            int randomIndex;
            randomIndex = Random.Range(0, spawnLocations.Length);

            Instantiate(enemy.gameObject);

            enemy.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        }
    }

    public float getBasicEnemyTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public void setBasicEnemyTimeBetweenSpawns(float t)
    {
        timeBetweenSpawns = t;
    }
}
