using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void LevelStart()
    {
        SceneManager.LoadScene("Level");
    }
}
