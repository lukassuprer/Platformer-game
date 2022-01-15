using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform player;
    public GameObject bulletParent;
    private PlayerScript playerScript;
    private GameManager gameManager;
    public Transform enemyPosition;
    public int Health = 100;
    public GameObject enemyBullet;
    public TextMeshProUGUI scoreText;
    public float fireRate = 1f;
    public float nextFireTime;
    private bool kill = false;
    public Vector2 screenPoint;

    public void Score()
    {
        GameObject Score = GameObject.Find("Score");
        Score scoreScript = Score.GetComponent<Score>();
        scoreScript.converter += 100;
        scoreScript.score += 100;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bulletScript = collision.gameObject.GetComponent<Bullet>();
        EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Health -= bulletScript.bulletDamage;

            if (Health <= 0 && kill == false)
            {
                Destroy(gameObject);
                // Instantiate(scoreText, enemyPosition);
                // gameObject.SetActive(false);
                Score();
                kill = true;
            }

            StartCoroutine(wait());
        }

        if (collision.gameObject.tag.Equals("Lava"))
        {
            gameObject.SetActive(false);
        }

    }

    public void Update()
    {
        if (gameManager.playerDead == true)
        {
            gameObject.SetActive(false);
        }
            if (GameManager.playerInstance == null)
            {

            }
            else
            {

            }

        if (gameManager.playerDead == false && GameManager.playerInstance != null)
        {
            player = GameManager.playerInstance.transform;
        }
        
        if(kill == false){
            enemyPosition = GameManager.enemyInstance.transform;
        }

        if (gameManager.playerDead == false)
        {
            player.position = new Vector2(player.position.x, player.position.y);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (Time.time > nextFireTime)
            {
                Instantiate(enemyBullet, bulletParent.transform.position, Quaternion.identity);
                 nextFireTime = Time.time + fireRate;
            }
        }
    }
    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Awake()
    {
        GameManager.enemyInstance = this;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        kill = false;
    }
}
       
