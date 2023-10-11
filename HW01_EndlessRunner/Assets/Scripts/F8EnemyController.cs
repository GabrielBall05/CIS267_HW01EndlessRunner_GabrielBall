using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class F8EnemyController : MonoBehaviour
{
    private Vector3 startPos;
    private float timer = 0f;

    //Determined in unity editor (5, 1.5, 0.25)
    public float speed;
    public float xScale;
    public float yScale;

    // Start is called before the first frame update
    void Start()
    {
        //startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        //if (timer <= 6f)
        //{
        //    timer += Time.deltaTime;
        //    transform.Translate(Vector2.down * Time.deltaTime);

        //    startPos = transform.position;
        //}
        //else
        //{
        //    //This will not fall, only move in figure 8 and shoot at you (Formula off internet)
        //    transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
        //}

        if (timer >= 6f)
        {
            //This will not fall, only move in figure 8 and shoot at you (Formula off internet)
            transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
        }
        else
        {
            timer += Time.deltaTime;
            transform.Translate(Vector2.down * Time.deltaTime);

            startPos = transform.position;
        }


    }

    public void setSpeed(float s)
    {
        speed = s;
    }

    public void setXScale(float x)
    {
        xScale = x;
    }

    public void setYScale(float y)
    {
        yScale = y;
    }
}
