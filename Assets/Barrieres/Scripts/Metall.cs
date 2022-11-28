using UnityEngine;

public class Metall : MonoBehaviour
{
    private Animator anim;

    private bool isDestroy = false;
    private float animTimer = 0.7f;
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
        if (other.CompareTag("PoisonBullet"))
        {
            isDestroy = true;
            anim.SetBool("isDestroy", isDestroy);
        }
    }
}
