using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F8EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject enemy;
    private float timer = 0f;
    //Start value: 15, Getter and Setter to change via time slow collectable (double the value)
    public float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        //Automatic 15 seconds between spawns
        timeBetweenSpawns = 15f;

        //===
        //Spawn one in to start off with
        int randomIndex;
        randomIndex = Random.Range(0, spawnLocations.Length);

        Instantiate(enemy.gameObject);

        if (randomIndex == 2 || randomIndex == 3)
        {
            enemy.gameObject.GetComponent<F8EnemyController>().setXScale(0.5f);
            enemy.gameObject.GetComponent<F8EnemyController>().setXScale(0.5f);
        }

        enemy.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        //===

        spawnF8Enemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnF8Enemies()
    {
        //Waits 15 seconds then spawns Figure 8 enemy. Will do forever
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

            if (randomIndex == 2 || randomIndex == 3)
            {
                enemy.gameObject.GetComponent<F8EnemyController>().setXScale(0.5f);
                enemy.gameObject.GetComponent<F8EnemyController>().setXScale(0.5f);
            }

            enemy.transform.position = new Vector2(spawnLocations[randomIndex].transform.position.x, spawnLocations[randomIndex].transform.position.y);
        }
    }

    public float getF8EnemyTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public void setF8EnemyTimeBetweenSpawns(float t)
    {
        timeBetweenSpawns = t;
    }
}
