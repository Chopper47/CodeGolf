using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public float volumeToSet { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PlaySong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySong()
    {
        SoundManager.instance.PlayMusic(MusicType.MAINMENU);
        ChangeSFXVolume(1);
        ChangeMusicVolume(1);
    }

    /// <summary>
    /// Called by volume slider
    /// </summary>
    public void ChangeSFXVolume()
    {
        ChangeSFXVolume(volumeToSet);
    }

    void ChangeSFXVolume(float volume)
    {
        SoundManager.instance.sfxVolume = volume;
        SoundManager.instance.ChangeSFXVolume();
    }

    /// <summary>
    /// Called by volume slider
    /// </summary>
    public void ChangeMusicVolume()
    {
        ChangeMusicVolume(volumeToSet);
    }

    void ChangeMusicVolume(float volume)
    {
        SoundManager.instance.musicVolume = volume;
        SoundManager.instance.ChangeMusicVolume();
    }
}
