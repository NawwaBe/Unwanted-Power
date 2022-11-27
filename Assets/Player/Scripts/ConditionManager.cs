using UnityEngine;

public class ConditionManager : MonoBehaviour
{
    public float powerUpTime = 10f;
    public bool electricPower = false;

    public GameObject player;
    public GameObject electricPlayer;

    public void Start()
    {

    }

    public void Update()
    {
        if (!electricPower)
        {
            CheckPower();
        }

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

    private void CheckPower()
    {
        electricPower = player.GetComponent<PlayerController>().electricPower;
    }

    private void ElectricPower()
    {

    }

    private void Reset()
    {
        powerUpTime = 10f;
        electricPower = false;
        player.GetComponent<PlayerController>().electricPower = false;
    }
}
