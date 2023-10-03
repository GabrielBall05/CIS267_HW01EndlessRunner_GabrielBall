using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;
    private bool hasRapidFire;
    

    void Start()
    {
        //Debug.Log("Start");
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log("Update");
        movementHorizontal();
        shoot();
    }

    private void shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pew pew");
            //pew pew
            //shoot projectile
        }
        if (hasRapidFire && Input.GetKey(KeyCode.Space))
        {
            //ppppppppppppeeeeeeeeeeeeeewwwwwwwwwwwwwww
            Debug.Log("Pressing and Holding");
        }
    }
    
    private void movementHorizontal()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);
        //maybe call a flip player here (spaceship will tilt)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("RapidFire"))
        {
            hasRapidFire = true;
            Destroy(collision.gameObject);
        }
        //else if (collectable 2)
        //else if (collectable 3)
    }
}
