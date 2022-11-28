using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header ("Links")]
    public Transform firePoint;
    public GameObject bullet;
    public GameObject electricPlayerBall;
    public GameObject firePlayerBall;
    public GameObject poisonPlayerBall;
    public GameObject waterPlayerBall;

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
        
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerController>().firePower)
        {
            FireShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerController>().poisonPower)
        {
            PoisonShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerController>().waterPower)
        {
            WaterShoot();
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

    private void FireShoot()
    {
        Instantiate(firePlayerBall, firePoint.position, firePoint.rotation);
    }

    private void PoisonShoot()
    {
        Instantiate(poisonPlayerBall, firePoint.position, firePoint.rotation);
    }

    private void WaterShoot()
    {
        Instantiate(waterPlayerBall, firePoint.position, firePoint.rotation);
    }
}