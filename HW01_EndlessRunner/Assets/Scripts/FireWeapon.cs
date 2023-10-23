using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;

    private float timeBetweenShots;
    private float fireRate;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.25f;
    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("ppppeeeewwww");
            if (canFire)
            {
                canFire = false;
                shoot();
            }
        }
    }

    private void shoot()
    {
        Instantiate(bullet, muzzle.position, transform.rotation);
    }

    public void fireRapidly()
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
    }

    public void setFireRate(float f)
    {
        fireRate = f;
    }

    public float getFireRate()
    {
        return fireRate;
    }
}