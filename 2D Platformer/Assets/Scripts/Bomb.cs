using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 10f;
    public float radius = 5f;
    public float force = 700f;
    public int damage = 10;

    public GameObject explosionEffect;

    bool hasExploded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Bullet = collision.gameObject;
        Bullet bulletScript = Bullet.GetComponent<Bullet>();
        if (collision.gameObject.tag.Equals("Bullet") && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }
        else if (collision.gameObject.tag.Equals("Enemy Bullet") && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }

    }

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            EnemyScript enemyScript = obj.gameObject.GetComponent<EnemyScript>();
            PlayerScript playerScript = obj.gameObject.GetComponent<PlayerScript>();

            obj.GetComponent<Rigidbody2D>().AddForce(force * direction);

            if (Vector2.Distance(obj.gameObject.transform.position, transform.position) <= radius)
            {
                if (playerScript != null)
                {
                    playerScript.curHealth -= damage;
                    if (playerScript.curHealth <= 0)
                    {
                        Destroy(playerScript.gameObject);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}


