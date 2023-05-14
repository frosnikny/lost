using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerButton : MonoBehaviour
{
    public Animator animator;

    // private void Update()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         FadeToLevel();
    //     }
    // }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void OnDeathComplete()
    {
        SceneManager.LoadScene(10);
    }
}