using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header ("Links")]
    public Transform firePoint;
    public GameObject bullet;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}