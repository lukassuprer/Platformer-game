using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Magazine : ShopManager
{
   public float maxBullets;
   public float currentBullets;
   public TextMeshProUGUI ammo;
   private GunSpawner currentGun;
   public bool reloading = false;

    private void Start() {
        currentGun = FindObjectOfType<GunSpawner>();
        MagazineSize();
        // switch(gun){
        //     case 1:
        //         //Rifle
        //         maxBullets = 30f;
        //         currentBullets = 30f;
        //         break;
        //     case 2:
        //         //Shotgun
        //         maxBullets = 10f;
        //         currentBullets = 10f;
        //         break;
        //     case 3: 
        //         //GrenadeLauncher
        //         maxBullets = 6f;
        //         currentBullets = 6f;
        //         break;
        //     case 4:
        //         //Pistol
        //         maxBullets = 10f;
        //         currentBullets = 10f;
        //         break;
        //     case 5:
        //         //RocketLauncher
        //         maxBullets = 1f;
        //         currentBullets = 1f;
        //         break;

        // }
    }
   public void Update() {
       //ammo.text = $"{currentBullets}/{maxBullets}";
       Reload();
   }

   private void MagazineSize(){
       Gun magazineSize = guns[gun];
       maxBullets = magazineSize.gunMagazine;
       currentBullets = magazineSize.gunMagazine;
   }

   private void Reload(){
       if(currentBullets <= 0 && !reloading){   
           ammo.text = $"0/{maxBullets}";
           StartCoroutine(waitReload());
       }
       else{
           ammo.text = $"{currentBullets}/{maxBullets}";
       }
   }

   IEnumerator waitReload(){
       reloading = true;
       yield return new WaitForSeconds(2);
       currentBullets = maxBullets;
       reloading = false;
   }
}
