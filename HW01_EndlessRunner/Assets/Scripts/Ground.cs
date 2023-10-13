using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //If an enemy gets past player/hits me (the ground):
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy hit the ground (made it past player): deduct points and destroy enemy gameObject
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Deducts 10% of total score if an enemy gets past you
            int deduct = (int)(GetComponent<PlayerScore>().getScore() * (-0.1));
            //Debug.Log(deduct);
            //Change the negative number accordingly for if it's not deducting enough/deducting too much

            //Set player score from the PlayerScore.cs script that we have access to because the script is also attached to enemies
            GetComponent<PlayerScore>().setPlayerScore(deduct);

            Destroy(collision.gameObject);
        }
    }
}
