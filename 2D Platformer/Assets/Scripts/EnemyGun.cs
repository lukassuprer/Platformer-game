using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    private GameManager gameManager;

    private void Update()
    {
        if (GameManager.playerInstance == null)
        {

        }
        else
        {

        }
        if (gameManager.playerDead == false && GameManager.playerInstance != null)
        {
            target = GameManager.playerInstance.transform;
        }
        
         Vector2 direction = target.position - transform.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
}
