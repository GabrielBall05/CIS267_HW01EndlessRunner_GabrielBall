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
        //maybe call a flip player here (spaceship will tilt)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("RapidFire"))
        {
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableValue();
            collision.GetComponent<Collectables>().destroyCollectable();
            GetComponent<PlayerScore>().setPlayerScore(thisCollectableValue);
            hasRapidFire = true;
        }
        if (collision.gameObject.CompareTag("Nuke"))
        {
            //Get Valye
            int thisCollectableValue = collision.GetComponent<Collectables>().getCollectableValue();
            //Destroy the GameObject
            collision.GetComponent<Collectables>().destroyCollectable();
            //Update the Score
            GetComponent<PlayerScore>().setPlayerScore(thisCollectableValue);
        }
        //else if (collectable 3)
        //else if (collectable 4)

        //Increase number of collectables collected for the scoring algorithm
        numCollectablesCollected++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //change "something" to the obstacle/enemy
        if(collision.gameObject.CompareTag("something"))
        {
            //end game because i just hit an enemy

            //In my enemy.cs i will have another oncollisionenter2d.
            //this function will also end game if enemy hit the ground (made it past the player)
        }
    }
}
