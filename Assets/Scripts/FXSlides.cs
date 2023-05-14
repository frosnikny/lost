using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSlides : MonoBehaviour
{
    // Play Global
    private static FXSlides instance = null;

    public bool abab = false;

    public static FXSlides Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}