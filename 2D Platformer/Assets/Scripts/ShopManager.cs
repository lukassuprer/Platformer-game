using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public List<Gun> guns = new List<Gun>();

    public List<Gun> ownedGuns = new List<Gun>();
    public TextMeshProUGUI noMoney;
    public TextMeshProUGUI textMoney;
    private float money;

    private Score scoreScript;
    public static int gun;
    public int boolean;
    public Gun so;

    private void Start(){
        scoreScript = GameObject.FindObjectOfType<Score>();
        // Debug.Log(guns[1].gunPrice);
        Load();

        //Load money from scoreScript
        money = PlayerPrefs.GetFloat("moneySave");
        textMoney.text = money.ToString();
        for(int i = 0; i < guns.Count; i++){
            Gun gunText = guns[i];
            gunText.textWeapon.text = gunText.gunPrice.ToString();
            // Debug.Log(guns[i].isUnlocked);
        }
        // so = SaveManager.Load();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void BuyGun(int index){
        Gun gunToBuy = guns[index];

        if (money >= gunToBuy.gunPrice && gunToBuy.isUnlocked == false)
        {
            ownedGuns.Add(gunToBuy);
            gunToBuy.isUnlocked = true;
            money -= gunToBuy.gunPrice;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gun = index;
            Save(index);
            SaveMoney();
            // SaveManager.Save(so);
        }
        else if (gunToBuy.isUnlocked == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gun = index;
            Save(index);
        }  
        else if (gunToBuy.gunPrice > money)
        {
            Debug.Log("nemáš dost peněz");
            StartCoroutine(wait());
        } 
    }

    private void Save(int index){
        PlayerPrefs.SetInt(guns[index].gunName, 1);
        PlayerPrefs.Save();
    } 
        private void SaveMoney() {
        PlayerPrefs.SetFloat("moneySaveShop", money);
        PlayerPrefs.Save();
    }
    private void Load(){
        for(int i = 0; i < guns.Count; i++){
            boolean = PlayerPrefs.GetInt(guns[i].gunName);
            if(boolean == 1)
            {
                guns[i].isUnlocked = true;
                guns[i].textWeapon.gameObject.SetActive(false);
                guns[i].gunImage.gameObject.SetActive(true);
            }
        }
    }
    public IEnumerator wait()
    {
        noMoney.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        noMoney.gameObject.SetActive(false);
    }
}