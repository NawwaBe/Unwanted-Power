using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public GameObject player;
    public Animator door;

    private bool keyInDoor = false;
    void Start()
    {
        
    }

    void Update()
    {
        door.SetBool("keyInDoor", keyInDoor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>().haveKey)
        {
            keyInDoor = true;
        }
    }
}
