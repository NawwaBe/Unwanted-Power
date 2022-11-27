using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header ("Links")]
    public Transform firePoint;
    public GameObject bullet;
    public GameObject electricPlayerBall;

    private bool simplePlayerShoot;
    void Update()
    {
        CheckShoot();

        if (Input.GetKeyDown(KeyCode.Space) && simplePlayerShoot)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerController>().electricPower)
        {
            ElectricShoot();
        }
    }

    private void CheckShoot()
    {
        if (!GetComponent<PlayerController>().electricPower && !GetComponent<PlayerController>().firePower && !GetComponent<PlayerController>().poisonPower && !GetComponent<PlayerController>().waterPower)
        {
            simplePlayerShoot = true;
        }
        else
        {
            simplePlayerShoot = false;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void ElectricShoot()
    {
        Instantiate(electricPlayerBall, firePoint.position, firePoint.rotation);
    }
}