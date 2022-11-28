using UnityEngine;

public class IceWallScript : MonoBehaviour
{
    private Animator anim;

    private bool isDestroy = false;
    private float animTimer = 0.6f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDestroy)
        {
            animTimer -= Time.deltaTime;
        }

        if (animTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FireBullet"))
        {
            isDestroy = true;
            anim.SetBool("isDestroy", isDestroy);
        }
    }
}