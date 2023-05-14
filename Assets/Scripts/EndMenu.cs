using UnityEngine;
using UnityEngine.SceneManagement;


public class EndMenu : MonoBehaviour
{
    public Animator animator;

    public void NewGame()
    {
        Debug.Log("Game started");
        FadeToLevel();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log("Hello");
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}