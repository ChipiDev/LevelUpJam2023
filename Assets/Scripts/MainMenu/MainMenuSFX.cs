using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSFX : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
