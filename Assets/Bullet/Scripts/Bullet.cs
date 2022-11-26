using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("Move Parameters")]
    public float bulletSpeed = 15f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Player" && hitInfo.gameObject.tag != "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}