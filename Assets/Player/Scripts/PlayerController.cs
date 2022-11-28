using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header ("Move Parameters")]
    public float playerSpeed = 10f;
    public float jumpForce = 16f;
    public float groundCheckRadius;
    public float jumpHeigth = 0.5f;
    public int amountOfJumps = 1;

    [Header("Condition Parameters")]
    public bool electricPower = false;
    public bool firePower = false;
    public bool poisonPower = false;
    public bool waterPower = false;

    [Header ("Life Parameters")]
    public int health = 3;

    [Header ("Links")]
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GameObject condition;
    public Image hp;
    public Image key;
    public Text timer;

    private float playerMove;
    public float animTimer = 0.5f;
    private int amountOfJumpsLeft;
    private bool isFacingRight = true;
    private bool isRuning;
    private bool isGrounded;
    private bool canJump;
    private bool onDamage;
    public bool haveKey = false;

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
        CheckHP();
        UpdateAnimations();

        if (onDamage)
        {
            Damage();
        }

        if (condition.GetComponent<ConditionManager>().inPower)
        {
            timer.GetComponent<Text>().text = condition.GetComponent<ConditionManager>().powerUpTime.ToString();
        }

        if (!condition.GetComponent<ConditionManager>().inPower)
        {
            timer.GetComponent<Text>().text = " ";
        }

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

    private void CheckHP()
    {
        if (health == 2)
        {
            hp.GetComponent<RectTransform>().anchoredPosition = new Vector2 (100, -50);
        }

        if (health == 1)
        {
            hp.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50);
        }

        if (health == 0)
        {
            hp.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -50);
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isRuning", isRuning);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("electricPower", electricPower);
        anim.SetBool("firePower", firePower);
        anim.SetBool("poisonPower", poisonPower);
        anim.SetBool("waterPower", waterPower);
        anim.SetBool("onDamage", onDamage);
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
            onDamage = true;         
        }

        if (!condition.GetComponent<ConditionManager>().inPower)
        {
            if (other.gameObject.CompareTag("FireSkill"))
            {
                Destroy(other.gameObject);
                firePower = true;
            }

            if (other.gameObject.CompareTag("ElectricSkill"))
            {
                Destroy(other.gameObject);
                electricPower = true;
            }

            if (other.gameObject.CompareTag("PoisonSkill"))
            {
                Destroy(other.gameObject);
                poisonPower = true;
            }

            if (other.gameObject.CompareTag("WaterSkill"))
            {
                Destroy(other.gameObject);
                waterPower = true;
            }
        }     
        
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            haveKey = true;
            key.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            onDamage = true;
            playerSpeed *= 0.4f;

        }
    }

    private void Damage()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 1f);

        animTimer -= Time.deltaTime;

        if (animTimer < 0)
        {
            ReturnAfterDamage();
        }
    }
    
    private void ReturnAfterDamage()
    {
        health -= 1;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        onDamage = false;
        animTimer = 0.5f;

        playerSpeed = 7f;
    }
}