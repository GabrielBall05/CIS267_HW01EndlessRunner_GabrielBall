using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    public float maxHealth; //150
    public float health;
    public float pointsForKilling;

    public float fallingSpeed; //1

    [SerializeField] HealthBar hb;

    // Start is called before the first frame update
    void Start()
    {
        hb = GetComponentInChildren<HealthBar>();
        hb.updateHealthbar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
        isDead();
    }

    private void moveEnemy()
    {
        //Falls at constant speed of fallingSpeed determined in Unity Editor
        //.left because my sprite is flipped 90 to the right
        transform.Translate(Vector2.left * fallingSpeed * Time.deltaTime);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
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
