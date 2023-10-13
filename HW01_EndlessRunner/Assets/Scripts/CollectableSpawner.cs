using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject[] collectableLocations;
    public GameObject Nuke;
    public GameObject TimeSlow;
    public GameObject RapidFire;
    private float nukeTimer = 0f;
    private float timeSlowTimer = 0f;
    private float rapidFireTimer = 0f;

    //Might change to do random collectable every 30s instead of a nuke every 90s, timeslow every 60s, and rapidfire every 45s

    //Time between spawns for Nuke (90s)
    private float timeBetweenNukeSpawns;
    //Time between spawns for TimeSlow (60s)
    private float timeBetweenTimeSlowSpawns;
    //Time between spawns for RapidFire (45s)
    private float timeBetweenRapidFireSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenNukeSpawns = 90f;
        timeBetweenTimeSlowSpawns = 60f;
        timeBetweenRapidFireSpawns = 45f;

        //I won't start off with any collectables
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnCollectables()
    {
        //Waits 90 seconds to spawn Nuke
        if (nukeTimer <= timeBetweenNukeSpawns)
        {
            nukeTimer += Time.deltaTime;
        }
        else
        {
            nukeTimer = 0f;

            int randomIndex;
            randomIndex = Random.Range(0, collectableLocations.Length);

            Instantiate(Nuke.gameObject);

            Nuke.transform.position = new Vector2(collectableLocations[randomIndex].transform.position.x, collectableLocations[randomIndex].transform.position.y);
        }

        //Waits 60 seconds to spawn TimeSlow
        if (timeSlowTimer <= timeBetweenTimeSlowSpawns)
        {
            timeSlowTimer += Time.deltaTime;
        }
        else
        {
            timeSlowTimer = 0f;

            int randomIndex;
            randomIndex = Random.Range(0, collectableLocations.Length);

            Instantiate(TimeSlow.gameObject);

            TimeSlow.transform.position = new Vector2(collectableLocations[randomIndex].transform.position.x, collectableLocations[randomIndex].transform.position.y);
        }

        //Waits 45 seconds to spawn RapidFire
        if (rapidFireTimer <= timeBetweenRapidFireSpawns)
        {
            rapidFireTimer += Time.deltaTime;
        }
        else
        {
            rapidFireTimer = 0f;

            int randomIndex;
            randomIndex = Random.Range(0, collectableLocations.Length);

            Instantiate(RapidFire.gameObject);

            RapidFire.transform.position = new Vector2(collectableLocations[randomIndex].transform.position.x, collectableLocations[randomIndex].transform.position.y);
        }
    }
}
