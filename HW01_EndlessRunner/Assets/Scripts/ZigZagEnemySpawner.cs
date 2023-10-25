using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemySpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject enemy;
    private float timer = 0f;
    public float timeBetweenSpawns;

    private float halfMinuteTimer;
    private int halfMinutesPassed;

    // Start is called before the first frame update
    void Start()
    {
        halfMinuteTimer = 0;
        halfMinutesPassed = 0;

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
        spawnZigZagEnemies();

        hasMinutePassed();
    }

    public void spawnZigZagEnemies()
    {
        //Waits "timeBetweenSpawns" seconds then spawns zig zag enemy. Will do forever
        if (timer <= timeBetweenSpawns)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //Reset
            timer = 0f;

            //Spawns in at random spawn location
            int randomIndex;
            randomIndex = Random.Range(0, spawnLocations.Length);

            Instantiate(enemy.gameObject);

            enemy.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        }
    }

    //=========================
    //Time and Spawn Rate Stuff
    //Keeps track of how many half minutes have passed
    private void hasMinutePassed()
    {
        if (halfMinuteTimer >= 30)
        {
            halfMinuteTimer = 0;
            halfMinutesPassed++;
            changeSpawnTimes();
        }
        else
        {
            halfMinuteTimer += Time.deltaTime;
        }
    }

    private void changeSpawnTimes()
    {
        //Everything here will be hardcoded. Enemy spawn rates will keep speeding up until it reaches a "max speed" at 10 minutes
        if (halfMinutesPassed == 1)
        {
            timeBetweenSpawns = 8f;
        }
        else if (halfMinutesPassed == 2)
        {
            timeBetweenSpawns = 7f;
        }
        else if (halfMinutesPassed == 3)
        {
            timeBetweenSpawns = 6.5f;
        }
        else if (halfMinutesPassed == 4)
        {
            timeBetweenSpawns = 6f;
        }
        else if (halfMinutesPassed == 5)
        {
            timeBetweenSpawns = 5.5f;
        }
        else if (halfMinutesPassed == 6)
        {
            timeBetweenSpawns = 5.25f;
        }
        else if (halfMinutesPassed == 7)
        {
            timeBetweenSpawns = 5f;
        }
        else if (halfMinutesPassed == 8)
        {
            timeBetweenSpawns = 4.5f;
        }
        else if (halfMinutesPassed == 9)
        {
            timeBetweenSpawns = 4.25f;
        }
        else if (halfMinutesPassed == 10) //Max game speed
        {
            timeBetweenSpawns = 4f; //Max Zig Zag enemy spawn rate
        } //By this point, it's been 10 minutes and enemies spawn in very often, the player WILL die soon

        //Debug.Log(halfMinutesPassed + " minutes passed");
    }
    //Time and spawn rate stuff
    //=========================
}
