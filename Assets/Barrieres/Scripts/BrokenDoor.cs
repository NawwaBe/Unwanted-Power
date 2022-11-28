using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenDoor : MonoBehaviour
{
    public GameObject normalDoor;

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
            Instantiate(normalDoor, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ElectricBullet"))
        {
            isDestroy = true;
            anim.SetBool("isDestroy", isDestroy);
        }
    }
}
