using UnityEngine;

public class controllerPersonagem : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float moveX;
    public float jumpForce = 10f;
    private Rigidbody2D rb2d;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    [Header("Visual / Animação")]
    public Transform visual;
    private Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = visual.GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        moveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        Move();

        anim.SetBool("IsRunning", Mathf.Abs(moveX) > 0.1f && isGrounded);

        if (moveX > 0.01f)
        {
            visual.localScale = new Vector3(1, 1, 1);
        }
        else if (moveX < -0.01f)
        {
            visual.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Move()
    {
        rb2d.linearVelocity = new Vector2(moveX * moveSpeed, rb2d.linearVelocity.y);
    }

    void Jump()
    {
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
    }


}
