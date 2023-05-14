using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseTaker : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                offPause();
            }
            else
            {
                onPause();
            }
        }
    }

    private void Start()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void offPause()
    {
        pauseMenu.SetActive(false);
        paused = false;
    }

    public void onPause()
    {
        pauseMenu.SetActive(true);
        paused = true;
    }
}