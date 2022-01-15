using UnityEngine;

public class BulletGrenade : Bullet
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
        if (!collision.gameObject.tag.Equals("Player") && !collision.gameObject.tag.Equals("PowerUp") && !collision.gameObject.tag.Equals("Enemy Bullet"))
        {
            Explode();
            hasExploded = true;
            Destroy(gameObject);
        }
        else if (hasExploded == false && collision.gameObject.tag.Equals("Enemy") && collision.gameObject.tag.Equals("Ground") && !collision.gameObject.tag.Equals("Player"))
        {
            Explode();
            hasExploded = true;
        }
    }
}