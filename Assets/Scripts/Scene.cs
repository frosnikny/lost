using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void LoadScene()
    {
        // animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
