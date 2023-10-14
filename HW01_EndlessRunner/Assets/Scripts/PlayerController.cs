using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;

    public int numCollectablesCollected;
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
    }

    void Update()
    {
        //Debug.Log("Update");
        movementHorizontal();
        shoot();

        //Ability stuff
        if (hasTimeSlow)
        {
            timeSlow();
        }
        if (hasRapidFire)
        {
            //rapidFire();
        }
    }

    private void shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pew pew");
            //pew pew
        }
        if (hasRapidFire && Input.GetKey(KeyCode.Space))
        {
            //ppppppppppppeeeeeeeeeeeeeewwwwwwwwwwwwwww
            Debug.Log("Pressing and Holding");
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
            GetComponent<PlayerScore>().setPlayerScore(thisCollectableValue);
            collision.GetComponent<Collectables>().destroyCollectable();

            //Ability Stuff
        }
        //If TIMESLOW
        if (collision.gameObject.CompareTag("TimeSlow"))
        {
            //Add Score
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            GetComponent<PlayerScore>().setPlayerScore(thisCollectableValue);
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
            GetComponent<PlayerScore>().setPlayerScore(thisCollectableValue);
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
                //Double player projectile speed to compensate

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
            hasTimeSlow = false;
            x = 1;
        }
    }

    private void rapidFire()
    {
        if (rapidFireTimer >= 0)
        {
            //change firerate

            rapidFireTimer -= Time.deltaTime;
        }
        else
        {
            //change firerate back

            hasRapidFire = false;
        }
    }
}
