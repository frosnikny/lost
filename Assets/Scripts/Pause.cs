using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // public void PlayGame()
    // {
    //     Debug.Log("Game started");
    //     // FadeToLevel();
    //     // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    // public void FadeToLevel()
    // {
    //     animator.SetTrigger("FadeOut");
    // }
    //
    // public void OnFadeComplete()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    public void ExitGameMenu()
    {
        // Debug.Log("Game closed");
        SceneManager.LoadScene(0);
    }
}