using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;

    private float timeBetweenShots;
    private float fireRate;
    private bool canFire = true;
    //6 to match the amount of time the F8 enemy falls before starting to do figure 8
    private float timeBeforeFirstFire = 6f;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1.75f;
    }

    // Update is called once per frame
    void Update()
    {
        //Only start shooting once the 6 seconds are up
        if (timeBeforeFirstFire <= 0)
        {
            if (timeBetweenShots <= 0)
            {
                timeBetweenShots = fireRate;
                //Enemy can now fire
                canFire = true;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }

            if (canFire)
            {
                //Don't check for key input since the enemy will just shoot every time it is ready to shoot

                //Rest canFire to false
                canFire = false;
                shoot();
            }
        }
        //If 6 seconds aren't up, decrement timeBeforeFirstFire
        else
        {
            timeBeforeFirstFire -= Time.deltaTime;
        }
    }

    private void shoot()
    {
        Instantiate(bullet, muzzle.position, transform.rotation);
    }
}