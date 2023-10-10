using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject GameManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetComponent<GameManager>();
    }

    //If an enemy hits me (the ground):
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy hit the ground (made it past player): deduct points and destroy enemy gameObject
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Enemy should also have access to the clock to find a good value to deduct
            int deduct = (int)gm.getTime() * (-10);
            //Change the negative number accordingly for if it's not deducting enough/deducting too much

            //Set player score from the PlayerScore.cs script that we have access to because the script is also attached to enemies
            GetComponent<PlayerScore>().setPlayerScore(deduct);

            Destroy(collision.gameObject);
        }
    }
}
