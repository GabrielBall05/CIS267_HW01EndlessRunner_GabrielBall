using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;

    private float timeBetweenShots;
    public float fireRate;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canFire)
            {
                canFire = false;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, muzzle.position, transform.rotation);
    }
}
