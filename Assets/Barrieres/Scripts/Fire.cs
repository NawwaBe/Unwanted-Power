using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator anim;

    private bool isDestroy = false;
    private float animTimer = 1.2f;
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
        if (other.CompareTag("WaterBullet"))
        {
            isDestroy = true;
            anim.SetBool("isDestroy", isDestroy);
        }
    }
}
