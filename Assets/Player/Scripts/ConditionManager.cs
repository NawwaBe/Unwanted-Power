using UnityEngine;

public class ConditionManager : MonoBehaviour
{
    public float powerUpTime = 10f;
    public bool inPower = false;

    public GameObject player;

    public void Start()
    {

    }

    public void Update()
    {
        if (!inPower)
        {
            CheckPower();
        }

        if (inPower)
        {
            powerUpTime -= Time.deltaTime;
        }

        if (powerUpTime <= 0)
        {
            Reset();
        }
    }

    private void CheckPower()
    {
        if (player.GetComponent<PlayerController>().electricPower || player.GetComponent<PlayerController>().firePower || 
            player.GetComponent<PlayerController>().poisonPower || player.GetComponent<PlayerController>().waterPower)
        {
            inPower = true;
        }
    }

    private void Reset()
    {
        powerUpTime = 10f;
        inPower = false;
        player.GetComponent<PlayerController>().electricPower = false;
        player.GetComponent<PlayerController>().firePower = false;
        player.GetComponent<PlayerController>().poisonPower = false;
        player.GetComponent<PlayerController>().waterPower = false;
    }
}
