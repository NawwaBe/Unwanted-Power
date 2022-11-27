using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Move Parameters")]
    public float playerSpeed = 10f;
    public float jumpForce = 16f;
    public float groundCheckRadius;
    public float jumpHeigth = 0.5f;
    public int amountOfJumps = 1;

    [Header("Condition Parameters")]
    public bool onElectricPower = false;

    [Header ("Life Parameters")]
    public int health = 3;

    [Header ("Links")]
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private float playerMove;
    [SerializeField] private float powerUpTime;
    private int amountOfJumpsLeft;
    private bool isFacingRight = true;
    private bool isRuning;
    private bool isGrounded;
    private bool canJump;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        amountOfJumpsLeft = amountOfJumps;
    }

    void Update()
    {
        CheckInput();
        CheckFlip();
        ChechCanJump();
        UpdateAnimations();

        if (health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        Movement();
    }

    private void CheckFlip()
    {
        if (isFacingRight && playerMove < 0)
        {
            Flip();
        }
        else if (!isFacingRight && playerMove > 0)
        {
            Flip();
        }
    }

    private void CheckInput()
    {
        playerMove = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpHeigth);
        }

        if (playerMove != 0)
        {
            isRuning = true;
        }
        else
        {
            isRuning = false;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    
    private void ChechCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (!isGrounded || amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isRuning", isRuning);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void Movement()
    {
        rb.velocity = new Vector2(playerMove * playerSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);
            amountOfJumpsLeft--;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
        }

    }
}