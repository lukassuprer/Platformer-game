using UnityEngine;

public class JumpPowerUp : PowerUp
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript playerScript = collision.GetComponent<PlayerScript>();
        if (collision.tag == "Player")
        {
            if (playerScript)
            {
                playerScript.jumpPower += increase;
                Destroy(gameObject);
            }
        }
    }
}
