using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 15f;
    public int extraJumps = 1;
    public ParticleSystem dust;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform feet;
    public HealthBar healthBar;

    public int jumpCount = 0;
    public bool isGrounded;
    public float mx;
    public float jumpCoolDown;

    public int curHealth = 0;
    public int maxHealth = 100;

    public bool isDead;

    public void Update()
    {
        mx = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CheckGrounded();

        Move();

        //Otočka
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float rotateY = 0f;

        if (mousePos.x <= transform.position.x)
        {
            rotateY = 180f;
        }

        transform.eulerAngles = new Vector3(transform.rotation.x, rotateY, transform.rotation.z);

        if (curHealth <= 0)
        {
            isDead = true;
            Dead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Lava"))
        {
            curHealth -= 100;
            isDead = true;
            healthBar.SetHealth(curHealth);
            Dead();
        }
    }

    public void Jump()
    {
        if (isGrounded || jumpCount < extraJumps)
        {
            CreateDust();
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }
    }

    public void Move()
    {
        mx = Input.GetAxis("Horizontal");
        float move = mx * speed;
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

    public void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void Dead()
    {
        if (isDead == true)
        {
            gameObject.SetActive(false);
            GameManager.playerInstance = null;
        }
    }

    public void CreateDust()
    {
        dust.Play();
    }

    public void Start()
    {
        isDead = false;
        curHealth = maxHealth;
        healthBar.SetHealth(curHealth);
    }

    public void Awake()
    {
        GameManager.playerInstance = this;
    }
}