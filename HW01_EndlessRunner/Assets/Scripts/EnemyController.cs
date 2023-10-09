using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyRigidBody;
    public int fallingSpeed;

    public GameObject GameManager;
    private GameManager gm;


    private Vector3 startPos;

    //Determined in unity editor (5, 2, 0.5)
    public float speed;
    public float xScale;
    public float yScale;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        gm = GameManager.GetComponent<GameManager>();

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        determineEnemyMovement();

    }

    private void determineEnemyMovement()
    {
        //If basic falling enemy
        if (gameObject.CompareTag("Enemy"))
        {
            //Falls at constant speed of fallingSpeed determined in Unity Editor
            transform.position -= transform.up * Time.deltaTime * fallingSpeed;
        }
        //If figure 8 falling enemy do this other movement formula
        else if (gameObject.CompareTag("Figure8Enemy"))
        {           //This will not fall, only move in figure 8 and shoot at you
            //Formula got off internet
            //ONLY LET SPAWN SOMEWHERE NEAR MIDDLE SO IT DOESN'T CLIP THROUGH THE WALLS
            transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
        }
        else if (gameObject.CompareTag("HorizontalEnemy"))
        {
            //Moves enemy horizontally back and forth

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy hit the ground (made it past player): deduct points and destroy enemy gameObject
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Enemy should also have access to the clock to find a good value to deduct
            int deduct = (int)gm.getTime() * (-10);
            //Change the negative number accordingly for if it's not deducting enough/deducting too much

            //Set player score from the PlayerScore.cs script that we have access to because the script is also attached to enemies
            GetComponent<PlayerScore>().setPlayerScore(deduct);

            destroyEnemy();
        }
    }


    public void destroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
