using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clipToPlay)
    {
        audioSource.clip = clipToPlay;
        audioSource.Play();
    } 
}
