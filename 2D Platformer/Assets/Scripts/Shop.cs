// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine;

// public class Shop : MonoBehaviour
// {
//     //public GameObject rifleButton;

//     private Score scoreScript;
//     private ShopText shopText;

//     // public static float gun;
//     public bool rifleUnlocked = false;
//     private bool shotgunUnlocked = false;
//     private bool pistolUnlocked = false;
//     private bool grenadeLauncherUnlocked = false;
//     private bool rocketLauncherUnlocked = false;
//     public float prizeRifle;
//     public float prizeShotgun;
//     public float prizeGrenadeLauncher;
//     public float prizePistol;
//     public float prizeRocketLauncher;
//     public TextMeshProUGUI noMoney;
//     public TextMeshProUGUI textMoney;
//     public Image rifleI;
//     public Image pistolI;
//     public Image shotgunI;
//     public Image grenadeLauncherI;
//     public Image rocketLauncherI;
//     private float money;
//     private void Start()
//     {
//         scoreScript = GameObject.FindObjectOfType<Score>();
//         shopText = FindObjectOfType<ShopText>();

//         //Load money from scoreScript
//         money = PlayerPrefs.GetFloat("moneySave");
//         //Load();
//         LoadRifle();

//         LoadPistol();

//         LoadShotgun();

//         LoadGrenadeLauncher();

//         LoadRocketLauncher();
//     }
//     public virtual void Update() {
//         textMoney.text = money.ToString();

//         if(Input.GetKeyDown(KeyCode.R)){
//             PlayerPrefs.DeleteAll();
//         }
//     }
//     private void SaveMoney() {
//         PlayerPrefs.SetFloat("moneySaveShop", money);
//         PlayerPrefs.Save();
//     }

//     public void Rifle(){
//         if (money >= prizeRifle && rifleUnlocked == false)
//         {
//             money -= 0;
//             gun = 1;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//             SaveRifle();
//             SaveMoney();
//         }
//         else if(money < prizeRifle && rifleUnlocked == false)
//         {
//             Debug.Log("Nemáš prachy");
//             StartCoroutine(wait());
//         }
//         else if(rifleUnlocked == true){
//             Debug.Log("unlocked");
//             shopText.textRifle.gameObject.SetActive(false);
//             rifleI.gameObject.SetActive(true);
//             prizeRifle = 0;

//             gun = 1;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//         }
//     }
//     public void Shotgun()
//     {
//         if (money >= prizeShotgun && shotgunUnlocked == false)
//         {
//             money -= 20;
//             gun = 2;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//             SaveShotgun();
//             SaveMoney();
//         }
//         else if(money < prizeShotgun && shotgunUnlocked == false)
//         {
//             Debug.Log("Nemáš prachy");
//             StartCoroutine(wait());
//         }
//         else if(shotgunUnlocked == true){
//             Debug.Log("unlocked");
//             shopText.textRifle.gameObject.SetActive(false);
//             shotgunI.gameObject.SetActive(true);
//             prizeRifle = 0;

//             gun = 2;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//         }
//     }

//     public void GrenadeLauncher()
//     {
//         if (money >= prizeGrenadeLauncher && grenadeLauncherUnlocked == false)
//         { 
//             money -= 30;
//             gun = 3;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//             SaveGrenadeLauncher();
//             SaveMoney();
//         }
//         else if(money < prizeGrenadeLauncher && grenadeLauncherUnlocked == false)
//         {
//             Debug.Log("Nemáš prachy");
//             StartCoroutine(wait());
//         }
//         else if(grenadeLauncherUnlocked == true){
//             Debug.Log("unlocked");
//             shopText.textRifle.gameObject.SetActive(false);
//             grenadeLauncherI.gameObject.SetActive(true);
//             prizeRifle = 0;

//             gun = 3;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//         }
//     }
//     public void Pistol()
//     {
//         if (money >= prizePistol && pistolUnlocked == false)
//         {
//             money -= 40;
//             gun = 4;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//             SavePistol();
//             SaveMoney();
//         }
//        else if(money < prizePistol && pistolUnlocked == false)
//         {
//             Debug.Log("Nemáš prachy");
//             StartCoroutine(wait());
//         }
//         else if(pistolUnlocked == true){
//             Debug.Log("unlocked");
//             shopText.textRifle.gameObject.SetActive(false);
//             pistolI.gameObject.SetActive(true);
//             prizeRifle = 0;

//             gun = 4;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//         }
//     }

//     public void RocketLauncher()
//     {
//         if (money >= prizeRocketLauncher && rocketLauncherUnlocked == false)
//         {
//             money -= 50;
//             gun = 5;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//             SaveRocketLauncher();
//             SaveMoney();
//         }
//         else if(money < prizeRocketLauncher && rocketLauncherUnlocked == false)
//         {
//             Debug.Log("Nemáš prachy");
//             StartCoroutine(wait());
//         }
//         else if(rocketLauncherUnlocked == true){
//             Debug.Log("unlocked");
//             shopText.textRifle.gameObject.SetActive(false);
//             rocketLauncherI.gameObject.SetActive(true);
//             prizeRifle = 0;

//             gun = 5;
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//         }
//     }

//     private void SaveShotgun(){
//         PlayerPrefs.SetString("unlockedShotgun", "true");
//         PlayerPrefs.Save();
//     }

//     private void SaveRifle(){
//         PlayerPrefs.SetString("unlockedRifle", "true");
//         PlayerPrefs.Save();
//     }

//     private void SavePistol(){
//         PlayerPrefs.SetString("unlockedPistol", "true");
//         PlayerPrefs.Save();
//     }

//     private void SaveGrenadeLauncher(){
//         PlayerPrefs.SetString("unlockedGrenadeLauncher", "true");
//         PlayerPrefs.Save();
//     }

//     private void SaveRocketLauncher(){
//         PlayerPrefs.SetString("unlockedRocketLauncher", "true");
//         PlayerPrefs.Save();
//     }
//     private void LoadPistol(){
//         string unlockedPistol = PlayerPrefs.GetString("unlockedPistol");
//         if(unlockedPistol == "true"){
//             pistolUnlocked = true;
//             shopText.textPistol.gameObject.SetActive(false);
//             pistolI.gameObject.SetActive(true);
//             prizePistol = 0;
//         }
//         else{
//             pistolUnlocked = false;
//         }
//     }

//     private void LoadShotgun(){
//         string unlockedShotgun = PlayerPrefs.GetString("unlockedShotgun");
//         if(unlockedShotgun == "true"){
//             shotgunUnlocked = true;
//             shopText.textShotgun.gameObject.SetActive(false);
//             shotgunI.gameObject.SetActive(true);
//             prizeShotgun = 0;
//         }
//         else{
//             shotgunUnlocked = false;
//         }
//     }

//     private void LoadGrenadeLauncher(){
//         string unlockedGrenadeLauncher = PlayerPrefs.GetString("unlockedGrenadeLauncher");
//         if(unlockedGrenadeLauncher == "true"){
//             grenadeLauncherUnlocked = true;
//             shopText.textGrenadeLauncher.gameObject.SetActive(false);
//             grenadeLauncherI.gameObject.SetActive(true);
//             prizeGrenadeLauncher = 0;
//         }
//         else{
//             grenadeLauncherUnlocked = false;
//         }
//     }

//     private void LoadRifle(){
//         string unlockedRifle = PlayerPrefs.GetString("unlockedRifle");
//         if(unlockedRifle == "true"){
//             rifleUnlocked = true;
//             shopText.textRifle.gameObject.SetActive(false);
//             rifleI.gameObject.SetActive(true);
//             prizeRifle = 0;
//         }
//         else{
//             rifleUnlocked = false;
//         }
//     }

//     private void LoadRocketLauncher(){
//         string unlockedRocketLauncher = PlayerPrefs.GetString("unlockedRocketLauncher");
//         if(unlockedRocketLauncher == "true"){
//             rocketLauncherUnlocked = true;
//             shopText.textRocketLauncher.gameObject.SetActive(false);
//             rocketLauncherI.gameObject.SetActive(true);
//             prizeRocketLauncher = 0;
//         }
//         else{
//             rocketLauncherUnlocked = false;
//         }
//     }
//     public IEnumerator wait()
//     {
//         noMoney.gameObject.SetActive(true);
//         yield return new WaitForSeconds(1);
//         noMoney.gameObject.SetActive(false);
//     }
// }