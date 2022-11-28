using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject levelManager;
    public PlayerController player;
    public FinalDoor final;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            levelManager.GetComponent<LevelManager>().Die();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (player.health <= 0)
        {
            levelManager.GetComponent<LevelManager>().Die();
        }

        if (final.keyInDoor)
        {
            levelManager.GetComponent<LevelManager>().ExitScene();
        }
    }
}
