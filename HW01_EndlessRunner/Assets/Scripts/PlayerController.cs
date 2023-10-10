using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;
    private bool hasRapidFire;
    public int numCollectablesCollected;

    public GameObject GameManager;
    private GameManager gm;
    

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
    }

    private void shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pew pew");
            //pew pew
            //shoot projectile
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

        if (collision.gameObject.CompareTag("RapidFire"))
        {
            //Give player Rapid Fire
            hasRapidFire = true;
            //Get Weighted Value (based off time) and amount of collectables collected
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            //Update the Score
            GetComponent<PlayerScore>().setPlayerScore(thisCollectableValue);
            //Destroy the GameObject
            collision.GetComponent<Collectables>().destroyCollectable();
        }
        if (collision.gameObject.CompareTag("Nuke"))
        {
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableWeightedValue() * numCollectablesCollected;
            GetComponent<PlayerScore>().setPlayerScore(thisCollectableValue);
            collision.GetComponent<Collectables>().destroyCollectable();
        }
        //else if (collectable 3)
        //else if (collectable 4)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player runs into an enemy, game over
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //end game because i just hit an enemy
            gm.setGameOver(true);
        }
    }
}
