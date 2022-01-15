using UnityEngine;
using System.Collections.Generic;

public class Shotgun : Weapon
{
    public int bulletCount = 10;
    public float spreadAngle = 5f;
    public float pelletFireVel = 1f;
    private Magazine magazineScript;

    List<Quaternion> bullets;

    private void Awake()
    {
        bullets = new List<Quaternion>(bulletCount);
        for (int i = 0; i < bulletCount; i++)
        {
            bullets.Add(Quaternion.Euler(Vector3.zero));
        }

        magazineScript = FindObjectOfType<Magazine>();
    }

    public override void Shoot()
    {
        if(magazineScript.reloading == false){

            for (int i = 0; i < bulletCount; i++)
            {
                bullets[i] = Random.rotation;
                GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, bullets[i], spreadAngle);
                b.GetComponent<Rigidbody2D>().AddForce(b.transform.right * pelletFireVel);
            }
            delay = Time.time + fireSpeed;
            magazineScript.currentBullets -= 1;
        }
    }
}       

