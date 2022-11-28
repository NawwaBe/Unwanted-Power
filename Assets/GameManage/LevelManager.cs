using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void LevelStart()
    {
        SceneManager.LoadScene("Level");
    }

    public void Die()
    {
        SceneManager.LoadScene("Restart");
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Exit");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
