using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D rb;
    public int bulletDamage = 10;
    public GameObject enemy;
    public HealthBar healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerScript.curHealth -= bulletDamage;
            healthBar.SetHealth(playerScript.curHealth);    
            Destroy(gameObject);
        }
        else if (!collision.gameObject.tag.Equals("Grenade Bullet"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
