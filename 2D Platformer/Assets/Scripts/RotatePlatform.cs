using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    

    private void Awake()
    {
        transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        //transform.rotation = Quaternion.AngleAxis(Time.time * speed, Vector3.forward);
    }
}
