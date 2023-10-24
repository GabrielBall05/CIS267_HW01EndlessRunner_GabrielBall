using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemyController : MonoBehaviour
{
    [SerializeField] HealthBar hb;

    public float maxHealth; //250
    public float health;

    public float movementSpeed; //3
    public float fallingSpeed; //1.5
    private bool moveRight;
    public float offset; //1.5
    private float startPosX;
    private bool hitLeftWall;
    private bool hitRightWall;

    // Start is called before the first frame update
    void Start()
    {
        //Start with moving to the left
        moveRight = false;
        //Find start x value
        startPosX = transform.position.x;
        //It hasn't hit either of the walls yet since it just spawned in
        hitLeftWall = false;
        hitRightWall = false;

        //Health bar stuff
        hb = GetComponentInChildren<HealthBar>();
        hb.updateHealthbar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Moves enemy left/right
        moveEnemyLateral();
        //Moves enemy down
        moveEnemyDown(); //Results in zig zag looking motion
    }

    private void moveEnemyLateral()
    {
        if (moveRight)
        {
            //Move enemy right
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            //Move left
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        //If I reached my right offset or hit the right wall:
        if (transform.position.x >= startPosX + offset || hitRightWall)
        {
            //Set booleans
            hitRightWall = false;
            moveRight = false;
        }
        //If I reached my left offset or hit the left wall:
        if (transform.position.x <= startPosX - offset || hitLeftWall)
        {
            //Set booleans
            hitLeftWall = false;
            moveRight = true;
        }
    }

    private void moveEnemyDown() //Moves enemy down also
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
    }

    //If i hit a wall, I want it to bounce off it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Wall1")) //Hit left wall
        {
            //Set boolean
            hitLeftWall = true;
        }
        else if (collision.gameObject.name.Equals("Wall2")) //Hit right wall
        {
            //Set boolean
            hitRightWall = true;
        }

        //If enemy got hit by a player's bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Destroy the bullet
            Destroy(collision.gameObject);
            //Decrement health by the bullet's damage
            health -= collision.gameObject.GetComponent<BulletController>().getBulletDamage();
            //Update health bear
            hb.updateHealthbar(health, maxHealth);

            //Check right away if health is <= 0, meaning enemy is dead
            if (health <= 0)
            {
                Destroy(this.gameObject);
                //Add "maxHealth" value to player score (250)
                GetComponent<GameManager>().addToTotalPlayerScore(maxHealth);
            }
        }
    }
}
