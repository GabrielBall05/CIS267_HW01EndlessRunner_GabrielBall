using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemySpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject enemy;
    private float timer = 0f;
    //Start value: 8, Getter and Setter to change via time slow collectable (double the value)
    public float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        //Automatic 5 seconds between spawns
        timeBetweenSpawns = 8f;

        //===
        //Spawn one in to start off with
        int randomIndex;
        randomIndex = Random.Range(0, spawnLocations.Length);

        Instantiate(enemy.gameObject);

        enemy.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        //===

        spawnZigZagEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnZigZagEnemies()
    {
        //Waits 8 seconds then spawns zig zag enemy. Will do forever
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

    public float getZigZagEnemyTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public void setZigZagEnemyTimeBetweenSpawns(float t)
    {
        timeBetweenSpawns = t;
    }
}
