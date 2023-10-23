using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;

    private int numCollectablesCollected;
    //Player ability bools
    private bool hasRapidFire = false;
    private bool hasTimeSlow = false;

    //Ability Timers
    private float timeSlowTimer;
    private float rapidFireTimer;

    public GameObject GameManager;
    private GameManager gm;

    private int x = 1;
    

    void Start()
    {
        //Debug.Log("Start");
        playerRigidBody = GetComponent<Rigidbody2D>();
        gm = GameManager.GetComponent<GameManager>();

        numCollectablesCollected = 0;
    }

    void Update()
    {
        //Debug.Log("Update");
        movementHorizontal();

        //Ability stuff
        if (hasTimeSlow)
        {
            timeSlow();
        }
        if (hasRapidFire)
        {
            rapidFire();
        }
    }

    
    private void movementHorizontal()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Increase number of collectables collected for the scoring algorithm
        numCollectablesCollected++;

        //If NUKE
        if (collision.gameObject.CompareTag("Nuke"))
        {
            //Add Score
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            gm.addToTotalPlayerScore(thisCollectableValue);
            collision.GetComponent<Collectables>().destroyCollectable();

            //Ability Stuff
            //Array to store objects to destroy
            GameObject[] destroyObjects;
            //Finds all game objects with the tag "enemy" and returns all of them in an array
            destroyObjects = GameObject.FindGameObjectsWithTag("Enemy");
            //Cycle through the array to destroy all those game objects
            for(int i = 0; i < destroyObjects.Length; i++)
            {
                Destroy(destroyObjects[i]);
            }
        }
        //If TIMESLOW
        if (collision.gameObject.CompareTag("TimeSlow"))
        {
            //Add Score
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            gm.addToTotalPlayerScore(thisCollectableValue);
            collision.GetComponent<Collectables>().destroyCollectable();

            //Give player TimeSlow
            hasTimeSlow = true;
            timeSlowTimer = 5; //Ability lasts 10 seconds because it halved the speed of everything, including time

        }
        //If RAPIDFIRE
        if (collision.gameObject.CompareTag("RapidFire"))
        {
            //==
            //Add score
            //Get Weighted Value (based off time) and amount of collectables collected
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            //Update the Score
            gm.addToTotalPlayerScore(thisCollectableValue);
            //Destroy the GameObject
            collision.GetComponent<Collectables>().destroyCollectable();
            //==

            //Give player Rapid Fire
            hasRapidFire = true;
            rapidFireTimer = 10; //Ability lasts 10 seconds

        }

        //if (collectable 4)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player runs into an enemy, game over
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gm.setGameOver(true);
        }
    }

    //=============
    //Ability Stuff
    private void timeSlow()
    {
        if (timeSlowTimer >= 0)
        {
            //Only want to do this if the game is not over. Otherwise, game will still play in the background of GameOverMenu
            if (gm.getGameOver() == false)
            {
                //Drop time scale to half speed
                Time.timeScale = 0.5f;
            }

            //I only want to execute these statements once
            if (x == 1)
            {
                //Double movement speed to compensate
                movementSpeed = movementSpeed * 2;
                //Double projectile speed to compensate

                //Double firerate to compensaet
                GetComponentInChildren<FireWeapon>().setFireRate((float)GetComponentInChildren<FireWeapon>().getFireRate() / 2);

                x = 2;
            }

            //Decrement timer
            timeSlowTimer -= Time.deltaTime;
        }
        else
        {
            //Reset
            Time.timeScale = 1;

            movementSpeed = movementSpeed / 2;
            GetComponentInChildren<FireWeapon>().setFireRate((float)GetComponentInChildren<FireWeapon>().getFireRate() * 2);
            hasTimeSlow = false;
            x = 1;
        }
    }

    private void rapidFire()
    {
        if (rapidFireTimer >= 0)
        {
            //change firerate to a set value of 0.1 (10 bullets per second)
            GetComponentInChildren<FireWeapon>().setFireRate(0.1f);


            GetComponentInChildren<FireWeapon>().fireRapidly();
            

            rapidFireTimer -= Time.deltaTime;
        }
        else
        {
            //change firerate back to default (0.25)
            GetComponentInChildren<FireWeapon>().setFireRate(0.25f);

            hasRapidFire = false;
        }
    }
}
