using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEditor.UI;

public class GameManager : MonoBehaviour
{
    public static PlayerScript playerInstance = null;
    public static EnemyScript enemyInstance = null;
    private PlayerScript playerScript;
    private EnemyScript enemyScript;
    public TextMesh scoreText;
    public bool playerDead;
    public bool enemyDead;
    Camera cam;
    public Vector2 enemyPos;

    private void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
        enemyScript = GameObject.FindObjectOfType<EnemyScript>();
        playerDead = false;
        enemyDead = false;

        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (playerScript.isDead == true)
        {
            playerDead = true;
        }
        else
        {
            playerDead = false;
        }   

        if(enemyScript.Health <= 0 && enemyScript != null){
            enemyDead = true;
        }
        else{
            enemyDead = false;
        }
        // if(enemyDead == true){
        //     StartCoroutine(enemyScore());
        // }
    }

    IEnumerator enemyScore()
    {
        Instantiate(scoreText, enemyInstance.transform.position, enemyInstance.transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(scoreText);
    }
}