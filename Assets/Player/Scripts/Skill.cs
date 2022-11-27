using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool electricPower = false;
    public float powerUpTime = 30f;


    void Start()
    {
        
    }

    void Update()
    {
        if (electricPower)
        {
            ElectricPower();
            powerUpTime -= Time.deltaTime;
        }
        
        if (powerUpTime <= 0)
        {
            Reset();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "Skill")
            {
                Destroy(other.gameObject);
                electricPower = true;
            }
        }
        
    }

    private void ElectricPower()
    {
        
    }

    private void Reset()
    {
        powerUpTime = 10f;
        electricPower = false;
    }
}
