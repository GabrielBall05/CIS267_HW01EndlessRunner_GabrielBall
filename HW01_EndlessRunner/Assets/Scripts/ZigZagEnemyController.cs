using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemyController : MonoBehaviour
{
    [SerializeField] HealthBar hb;

    public float maxHealth; //250
    public float health;
    public float pointsForKilling;

    //3
    public float movementSpeed;
    //1.5
    public float fallingSpeed;
    private bool moveRight;
    //1.5
    public float offset;
    private float startPosX;
    private bool hitLeftWall;
    private bool hitRightWall;

    // Start is called before the first frame update
    void Start()
    {
        moveRight = false;
        startPosX = transform.position.x;
        hitLeftWall = false;
        hitRightWall = false;

        hb = GetComponentInChildren<HealthBar>();
        hb.updateHealthbar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Moves down in a zig zag
        moveEnemyLateral();
        moveEnemyDown();
        isDead();
    }

    private void moveEnemyLateral()
    {
        if (moveRight)
        {
            //Move alien right
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        if (transform.position.x >= startPosX + offset || hitRightWall)
        {
            hitRightWall = false;
            moveRight = false;
        }
        if (transform.position.x <= startPosX - offset || hitLeftWall)
        {
            hitLeftWall = false;
            moveRight = true;
        }
    }

    private void moveEnemyDown()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
    }

    //If i hit a wall, I want it to bounce off it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Wall1"))
        {
            hitLeftWall = true;
        }
        else if (collision.gameObject.name.Equals("Wall2"))
        {
            hitRightWall = true;
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health -= 50;
            hb.updateHealthbar(health, maxHealth);
        }
    }

    private void isDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);

            //Add "pointsForKilling" value to player score
            GetComponent<GameManager>().addToTotalPlayerScore(pointsForKilling);
        }
    }
}
