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
            transform.Rotate(0, 0, 90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Bullet"))
        {
            transform.Translate(transform.up * bulletSpeed * Time.deltaTime * (-1));
        }
        if (gameObject.CompareTag("EnemyBullet"))
        {
            transform.Translate(transform.up * bulletSpeed * Time.deltaTime);
        }
    }

    public void destroyBullet()
    {
        Destroy(this.gameObject);
    }
}
