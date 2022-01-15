using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public int bulletDamage = 50;
    public Transform player;

    public float radius = 5f;
    public float force = 500;
    public int damage = 10;

    public GameObject explosionEffect;

    public Transform enemyBullet;

    public bool hasExploded = false;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = transform.right * bulletSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
        if (!collision.gameObject.tag.Equals("Player") && !collision.gameObject.tag.Equals("PowerUp") && !collision.gameObject.tag.Equals("Enemy Bullet"))
        {
            Destroy(gameObject);
        }
    }

    public void Score()
    {
        GameObject Score = GameObject.Find("Score");
        Score scoreScript = Score.GetComponent<Score>();
        scoreScript.score += 1;
        scoreScript.converter += 1;
    }

    public void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            EnemyScript enemyScript = obj.gameObject.GetComponent<EnemyScript>();
            PlayerScript playerScript = obj.gameObject.GetComponent<PlayerScript>();
            float distance = Vector2.Distance(obj.transform.position, gameObject.transform.position);

            if (distance == 0.0f)
            {
                distance = 1f;
            }

            obj.GetComponent<Rigidbody2D>().AddForce((force / distance) * direction);

            if (Vector2.Distance(obj.gameObject.transform.position, transform.position) <= radius)
            {
                if (playerScript != null)
                {
                    playerScript.curHealth -= damage;
                    if (playerScript.curHealth <= 0)
                    {
                        // Destroy(playerScript.gameObject);
                        playerScript.gameObject.SetActive(false);
                        playerScript.isDead = true;
                    }
                }

                if (enemyScript != null)
                {
                    enemyScript.Health -= damage;

                    if (enemyScript.Health <= 0)
                    {
                        Destroy(enemyScript.gameObject);
                    }
                }


            }
        }
        GameObject ExplosionEffect = Instantiate(explosionEffect, transform.position, Quaternion.identity);


        Destroy(ExplosionEffect, 10);
        Destroy(gameObject);
    }
}





