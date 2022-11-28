using UnityEngine;

public class ElecticBall : MonoBehaviour
{
    [Header("Move Parameters")]
    public float ballSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * ballSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Enemy" && !hitInfo.gameObject.CompareTag("Bullet") && !hitInfo.gameObject.CompareTag("ElectricBullet") 
            && !hitInfo.gameObject.CompareTag("FireBullet") && !hitInfo.gameObject.CompareTag("WaterBullet") && !hitInfo.gameObject.CompareTag("PoisonBullet") 
            && !hitInfo.gameObject.CompareTag("BulletWall"))
        {
            Destroy(gameObject);
        }
    }
}