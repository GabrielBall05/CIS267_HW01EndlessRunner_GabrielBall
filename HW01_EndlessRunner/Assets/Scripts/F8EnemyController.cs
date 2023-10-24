using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class F8EnemyController : MonoBehaviour
{
    //Followed tutorial for healthbar
    [SerializeField] HealthBar hb;

    public float maxHealth; //650
    public float health;

    private Vector3 startPos;
    private float timer = 0f;

    public float speed; //5
    public float xScale; //1
    public float yScale; //0.5

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
        //Will fall down for 6 seconds first (to get on screen so it doesn't look like the enemy just appeared out of nowhere)
        if (timer >= 6f) //If I've reached my timer, start doing figure 8
        {
            //Starts moving in figure 8 patterm
            //Formula from the internet of course
            transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
        }
        else //Hasn't reached 6 seconds, keep moving down
        {
            //Decrement timer
            timer += Time.deltaTime;
            //Move down
            transform.Translate(Vector2.down * Time.deltaTime);
            //Update the start position so it knows where to do the figure 8 around
            startPos = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) //Player hit me with bullet
        {
            //Destroy bullet
            Destroy(collision.gameObject);
            //Decrement health by bullet damage
            health -= collision.gameObject.GetComponent<BulletController>().getBulletDamage();
            //Update health bar
            hb.updateHealthbar(health, maxHealth);

            //Check right away if health is 0 so I don't have to do it in update
            if (health <= 0)
            {
                Destroy(this.gameObject);
                //Add "maxHealth" value to player score
                GetComponent<GameManager>().addToTotalPlayerScore(maxHealth);
            }
        }
    }
}
