using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed;
    public float bulletLife;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyBullet", bulletLife);
        //I needed to do this for some reason to rotate the bullet even though the prefab is rotated already
        if (gameObject.CompareTag("Bullet"))
        {
            transform.Rotate(0, 0, -90);
        }
        else if (gameObject.CompareTag("EnemyBullet"))
        {
            //Rotate the other way since enemy will be shooting down instead of up like the player
            transform.Rotate(0, 0, 90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Bullet"))
        {
            //-1 goes up with my configuration
            transform.Translate(transform.up * bulletSpeed * Time.deltaTime * (-1));
        }
        if (gameObject.CompareTag("EnemyBullet"))
        {
            //Goes down with my configuration
            transform.Translate(transform.up * bulletSpeed * Time.deltaTime);
        }
    }

    public float getBulletDamage()
    {
        return bulletDamage;
    }

    //Don't delete
    //It's for Line 14: Invoke("destr...) to destroy the bullet after it reaches its life span
    public void destroyBullet()
    {
        Destroy(this.gameObject);
    }
}
