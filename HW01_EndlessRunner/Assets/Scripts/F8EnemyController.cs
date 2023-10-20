using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class F8EnemyController : MonoBehaviour
{
    //500
    public float health;
    public float pointsForKilling;

    private Vector3 startPos;
    private float timer = 0f;

    //Determined in unity editor (5, 1, 0.5)
    public float speed;
    public float xScale;
    public float yScale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
        isDead();
    }

    private void moveEnemy()
    {
        //Will fall down for 6 seconds first (to get on screen)
        if (timer >= 6f)
        {
            //This will not fall, only move in figure 8 and shoot at you (Formula off internet)
            transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
        }
        //Then will start doing figure 8
        else
        {
            timer += Time.deltaTime;
            transform.Translate(Vector2.down * Time.deltaTime);

            startPos = transform.position;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health -= 50;
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
