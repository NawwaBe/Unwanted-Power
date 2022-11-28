using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject levelManager;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            levelManager.GetComponent<LevelManager>().LevelStart();
        }
    }
}
