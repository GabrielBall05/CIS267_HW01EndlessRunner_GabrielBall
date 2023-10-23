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
        if (timeBeforeFirstFire <= 0)
        {
            if (timeBetweenShots <= 0)
            {
                timeBetweenShots = fireRate;
                canFire = true;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }

            if (canFire)
            {
                canFire = false;
                shoot();
            }
        }
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
