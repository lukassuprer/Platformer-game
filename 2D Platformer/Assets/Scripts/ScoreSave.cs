using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSave : MonoBehaviour
{
       public static float money;

       private void Awake(){
           money = PlayerPrefs.GetFloat("money");
       }


       private void OnApplicationQuit()
        {
         PlayerPrefs.SetFloat("money", money);
         PlayerPrefs.Save();
         }
    private void OnDisable(){
        Debug.Log(money);
         PlayerPrefs.SetFloat("money", money);
         PlayerPrefs.Save();
         Debug.Log(PlayerPrefs.GetFloat("money"));
    }
}
