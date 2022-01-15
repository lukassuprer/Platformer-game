using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript playerScript = collision.GetComponent<PlayerScript>();
        if (collision.tag == "Player")
        {
            if (playerScript)
            {
                playerScript.speed += increase;
                Destroy(gameObject);
            }
        }
    }
}
