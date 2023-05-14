using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instanse { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        instanse = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
    


}
