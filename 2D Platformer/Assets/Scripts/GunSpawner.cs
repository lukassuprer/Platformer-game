using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : ShopManager
{
    private GameManager gameManager;
    private Transform player;

    // public GameObject rifle;
    // public GameObject shotgun;
    // public GameObject grenadeLauncher;
    // public GameObject rocketLauncher;
    // public GameObject pistol;

    // public GameObject weapon;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameManager.playerInstance.transform;
        spawnGun();

        // switch (gun)
        // {
        //     case 1:
        //         //Rifle
        //         GameObject myRifle = Instantiate(rifle, player.position, transform.rotation) as GameObject;
        //         myRifle.transform.parent = player;
        //         break;
        //     case 2:
        //         //Shotgun
        //         GameObject myShotgun = Instantiate(shotgun, player.position, transform.rotation) as GameObject;
        //         myShotgun.transform.parent = player;
        //         break;
        //     case 3:
        //         //GrenadeLauncher
        //         GameObject myGrenadeLauncher = Instantiate(grenadeLauncher, player.position, transform.rotation) as GameObject;
        //         myGrenadeLauncher.transform.parent = player;
        //         break;
        //     case 4:
        //         //Pistol
        //         GameObject myPistol = Instantiate(pistol, player.position, transform.rotation) as GameObject;
        //         myPistol.transform.parent = player;
        //         break;
        //     case 5:
        //         //RocketLauncher
        //         GameObject myRocketLauncher = Instantiate(rocketLauncher, player.position, transform.rotation) as GameObject;
        //         myRocketLauncher.transform.parent = player;
        //         break;
        // }

    }
        private void spawnGun(){
            Gun gunToSpawn = guns[gun];
            GameObject weapon = gunToSpawn.objGun;

            GameObject myWeapon = Instantiate(weapon, player.position, transform.rotation) as GameObject;
                myWeapon.transform.parent = player;
        }
}
