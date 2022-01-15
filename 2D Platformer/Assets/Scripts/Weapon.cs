using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float timeDelay = 2.0f;
    public float lastShotTime = 0;

    public float fireSpeed = 0.5f;
    public float delay;

    private Magazine magazineScript;

    private void Start() {
        magazineScript = FindObjectOfType<Magazine>();
    }

    virtual public void Shoot()
    {
        if(magazineScript.reloading == false){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            magazineScript.currentBullets -= 1;
            Destroy(bullet, 5f);
        }
    }

    virtual public void Update()
    {
        
        Vector3 mousePos = Input.mousePosition;

 
            Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - gunPos.x;
            mousePos.y = mousePos.y - gunPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;


            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -angle));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            }

            if (Input.GetButtonDown("Fire1") && Time.time >= delay)
            {
                Shoot();
                delay = Time.time + fireSpeed;
            }
    }
}

