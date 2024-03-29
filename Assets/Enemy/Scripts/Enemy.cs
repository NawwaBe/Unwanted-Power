using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    public float attackCooldown;
    public float range;
    public float colliderDistance;

    [Header("Life Parameters")]
    public int health = 3;

    [Header("Links")]
    public LayerMask playerLayer;
    public BoxCollider2D boxCollider2D;
    public Transform firePoint;
    public GameObject Ball;
    public GameObject Skill;

    private float coolDownTimer = Mathf.Infinity;
    private float animTimer = 0.5f;
    private bool onDamage = false;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        coolDownTimer += Time.deltaTime;
        if (PlayerInSigth())
        {
            if (coolDownTimer >= attackCooldown)
            {
                coolDownTimer = 0;
                anim.SetTrigger("inAttack");
                Shoot();
            }
        }

        if (onDamage)
        {
            Damage();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("ElectricBullet") || other.gameObject.CompareTag("FireBullet") 
            || other.gameObject.CompareTag("WaterBullet") || other.gameObject.CompareTag("PoisonBullet"))
        {
            onDamage = true;
        }
        
    }

    private bool PlayerInSigth()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider2D.bounds.size.x * range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void Shoot()
    {
        Instantiate(Ball, firePoint.position, firePoint.rotation);
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(Skill, transform.position, transform.rotation);
    }

    private void Damage()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 1f);

        animTimer -= Time.deltaTime;

        if (animTimer < 0)
        {
            health -= 1;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            onDamage = false;
            animTimer = 0.5f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider2D.bounds.size.x * range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z));
    }
}