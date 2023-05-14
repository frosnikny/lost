using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFX : MonoBehaviour
{
    // public AudioClip menu;
    private AudioSource audioSource;
    public float volume=0.5f;
    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        // audioSource.clip = menu;
        // audioSource.loop = true;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
