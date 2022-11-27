using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPlayerBall : MonoBehaviour
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
        if (hitInfo.gameObject.tag != "Player" && hitInfo.gameObject.tag != "EnemyBullet" && hitInfo.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
