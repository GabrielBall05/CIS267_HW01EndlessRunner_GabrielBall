using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    //Followed tutorial for healthbar
    [SerializeField] HealthBar hb;

    public float maxHealth; //150
    public float health;

    public float fallingSpeed; //1

    // Start is called before the first frame update
    void Start()
    {
        //Health bar stuff
        hb = GetComponentInChildren<HealthBar>();
        hb.updateHealthbar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        //Falls at constant speed of fallingSpeed (1)
        //Transform left because my sprite is flipped 90 degrees to the right since I got this sprite online
        transform.Translate(Vector2.left * fallingSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) //Player hit me with a bullet
        {
            //Destroy bullet
            Destroy(collision.gameObject);
            //Decrement health by bullet damage
            health -= collision.gameObject.GetComponent<BulletController>().getBulletDamage();
            //Update health bar
            hb.updateHealthbar(health, maxHealth);

            //Check right away if enemy is dead so I don't have to constantly check it in update
            if (health <= 0)
            {
                Destroy(this.gameObject);
                //Add "maxHealth" value to player score
                GetComponent<GameManager>().addToTotalPlayerScore(maxHealth);
            }
        }
    }
}