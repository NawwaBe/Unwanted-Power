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
    public GameObject electricBall;
    public GameObject electricSkill;

    private float coolDownTimer = Mathf.Infinity;

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
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            health -= 1;
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
        Instantiate(electricBall, firePoint.position, firePoint.rotation);
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(electricSkill, new Vector2 (transform.position.x, transform.position.y - 0.5f), transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider2D.bounds.size.x * range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z));
    }
}