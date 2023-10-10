using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class F8EnemyController : MonoBehaviour
{
    private Vector3 startPos;

    //Determined in unity editor (5, 2, 0.5)
    public float speed;
    public float xScale;
    public float yScale;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        //This will not fall, only move in figure 8 and shoot at you
        //Formula got off internet
        //ONLY LET SPAWN SOMEWHERE NEAR MIDDLE SO IT DOESN'T CLIP THROUGH THE WALLS
        transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * speed) * xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed) * yScale);
    }
}
