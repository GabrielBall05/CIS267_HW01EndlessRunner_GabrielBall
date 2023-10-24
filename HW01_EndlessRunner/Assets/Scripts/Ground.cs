using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //If an enemy gets past player/enemy hits the ground:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy hit the ground (made it past player):
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Deducts 20% of total score
            //Change the negative number accordingly for if it's not deducting enough/deducting too much
            int deduct = (int)(GetComponent<GameManager>().getTotalPlayerScore() * (-0.2));
            //Debug.Log(deduct);

            //Add deduct to totalPlayerScore in GameManager (adds negative number so it really subtracts)
            GetComponent<GameManager>().addToTotalPlayerScore(deduct);

            //Destroy enemy
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a trigger (collectable) hits the ground, destroy it as well
        if (collision.gameObject.CompareTag("Nuke") || collision.gameObject.CompareTag("RapidFire") || collision.gameObject.CompareTag("TimeSlow"))
        {
            Destroy(collision.gameObject);
        }
    }
}