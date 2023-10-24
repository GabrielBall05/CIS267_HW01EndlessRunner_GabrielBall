using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;
    public int maxHealth; //250
    public float health;

    //Followed tutorial for health bar stuff
    [SerializeField] HealthBar hb;

    private int numCollectablesCollected;
    //Player ability bools
    private bool hasRapidFire = false;
    private bool hasTimeSlow = false;

    //Ability Timers
    private float timeSlowTimer;
    private float rapidFireTimer;

    public GameObject GameManager;
    private GameManager gm;

    private bool x = true; //I need this for time slow

    void Start()
    {
        //Debug.Log("Start");
        playerRigidBody = GetComponent<Rigidbody2D>();
        gm = GameManager.GetComponent<GameManager>();

        //Health bar stuff
        hb = GetComponentInChildren<HealthBar>();
        hb.updateHealthbar(health, maxHealth);

        numCollectablesCollected = 0;
    }

    void Update()
    {
        //Debug.Log("Update");
        movementHorizontal();

        //Ability stuff
        if (hasTimeSlow) //If I have Time Slow ability:
        {
            //Do its ability stuff
            timeSlow();
        }
        if (hasRapidFire)//If I have Rapid Fire ability:
        {
            //Do its ability stuff
            rapidFire();
        }
    }

    
    private void movementHorizontal()
    {
        //Move player laterally
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Increase number of collectables collected first for the scoring algorithm
        numCollectablesCollected++;

        //If NUKE
        if (collision.gameObject.CompareTag("Nuke"))
        {
            //Gets weighted collectable value (int Collectables script) and multiplies it by the # of collectables already collected
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            //Add that score
            gm.addToTotalPlayerScore(thisCollectableValue);
            //Destroy it
            Destroy(collision.gameObject);

            //Ability Stuff
            //Array to store objects to destroy
            GameObject[] destroyEnemies;
            //Finds all game objects with the tag "enemy" and returns all of them in an array
            destroyEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            //Cycle through the array to destroy all those game objects
            for(int i = 0; i < destroyEnemies.Length; i++)
            {
                Destroy(destroyEnemies[i]);
            }

            //Same thing with enemy bullets
            GameObject[] destroyBullets;
            destroyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
            for (int i = 0; i < destroyBullets.Length; i++)
            {
                Destroy(destroyBullets[i]);
            }
        }
        //If TIMESLOW
        if (collision.gameObject.CompareTag("TimeSlow"))
        {
            //Add Score
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            gm.addToTotalPlayerScore(thisCollectableValue);
            //Destroy it
            Destroy(collision.gameObject);

            //Give player Time Slow
            hasTimeSlow = true;
            timeSlowTimer = 5; //Ability lasts 10 seconds (not 5) because it halved the speed of everything, including time
        }
        //If RAPIDFIRE
        if (collision.gameObject.CompareTag("RapidFire"))
        {
            //Add score
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            gm.addToTotalPlayerScore(thisCollectableValue);
            //Destroy it
            Destroy(collision.gameObject);

            //Give player Rapid Fire
            hasRapidFire = true;
            rapidFireTimer = 10; //Ability lasts 10 seconds (Will never overlap with time slow because collectables spawn every 30s & my abilities last 10s)
        }
        //If Collectable 4
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player runs into an enemy:
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gm.setGameOver(true); //Game over
        }
        //If the figure 8 enemy hits me with one of its bullets:
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            //Destroy bullet
            Destroy(collision.gameObject);
            //Deduct the bullet's damage from my health
            deductPlayerHealth(collision.gameObject.GetComponent<BulletController>().getBulletDamage());
            //Update health bar
            hb.updateHealthbar(health, maxHealth);

            //check right away for whether or not I'm dead (health <= 0)
            if (health <= 0)
            {
                gm.setGameOver(true); //Game over because player is dead
            }

            //-100 points for getting shot, but I don't want to go in the negatives since that
            //would mess up the deducting of points when an enemy makes it past the player
            if (gm.getTotalPlayerScore() > 100)
            {
                gm.addToTotalPlayerScore(-100);
            }
            else
            {
                gm.addToTotalPlayerScore(gm.getTotalPlayerScore() * (-1));
            } //Will never make player score get into the negatives
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
                //Drop time scale to half speed for Time Slow
                Time.timeScale = 0.5f;
            }

            //I only want to execute these statements once or else it'll keep doing it every update until 10 seconds are up
            if (x)
            {
                //Double movement speed to compensate
                movementSpeed = movementSpeed * 2;
                //Double firerate to compensate
                GetComponentInChildren<FireWeapon>().setFireRate((float)GetComponentInChildren<FireWeapon>().getFireRate() / 2);
                x = false;
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
            hasTimeSlow = false; //Player no longer has time slow
            x = false;
        }
    }

    private void rapidFire()
    {
        if (rapidFireTimer >= 0)
        {
            //Change firerate to a set value of 0.08 (12.5 bullets per second)
            GetComponentInChildren<FireWeapon>().setFireRate(0.08f);
            
            //Decrement timer
            rapidFireTimer -= Time.deltaTime;
        }
        else //Reset
        {
            //Time up, change firerate back to default (0.25)
            GetComponentInChildren<FireWeapon>().setFireRate(0.25f);
            hasRapidFire = false; //Player no longer has rapid fire
        }
    }
    //Ability Stuff
    //=============

    //If player hits bullet, deduct bullet damage (50)
    private void deductPlayerHealth(float d)
    {
        health -= d;
    }
}