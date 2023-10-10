using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    public float fallingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        //Falls at constant speed of fallingSpeed determined in Unity Editor
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
    }

    public void destroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
