using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint, firepoint1, firepoint2, firepoint3;
    public GameObject bulletPrefab;
    public GameObject shotgunsprite;
    bool shotgunmode = false;

    public float bulletForce = 20f;
    void Start()
    {
        shotgunsprite.SetActive(false);
    }
    void Update()
    {
        //Nested control flow statements
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (shotgunmode == false)
            {
                shotgunmode = true;
                shotgunsprite.SetActive(true);
            }
            else
            {
                shotgunmode = false;
                shotgunsprite.SetActive(false);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (shotgunmode == false)
            {
                //TRY-CATCH
                try
                {
                    Shoot();
                }
                catch
                {
                    Debug.Log("Error");
                }
            }
            if (shotgunmode == true)
            {
                Shoutgun();
            }

        }
    }
    void Shoot()
    {
        //Encapsulation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //
        Destroy(bullet, 2);
    }
    void Shoutgun()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint1.up * bulletForce + new Vector3(0f, -15f, 0f), ForceMode2D.Impulse);
        Destroy(bullet, 2);

        GameObject bullet2 = Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        Rigidbody2D rb1 = bullet2.GetComponent<Rigidbody2D>();
        rb1.AddForce(firepoint2.up * bulletForce + new Vector3(0f, 0f, 0f), ForceMode2D.Impulse);
        Destroy(bullet2, 2);

        GameObject bullet3 = Instantiate(bulletPrefab, firepoint3.position, firepoint3.rotation);
        Rigidbody2D rb2 = bullet3.GetComponent<Rigidbody2D>();
        rb2.AddForce(firepoint3.up * bulletForce + new Vector3(0f, +15f, 0f), ForceMode2D.Impulse);
        Destroy(bullet3, 2);
    }
}
