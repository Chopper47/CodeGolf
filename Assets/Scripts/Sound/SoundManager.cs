using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum SoundType
{
    HITBALL,
    BUTTONCLICK,

}
public enum MusicType
{
    MAINMENU,

}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    [SerializeField] private AudioClip[] musicList;

    public float musicVolume { get; set; }
    public float sfxVolume { get; set; }

    public static SoundManager instance;
    public AudioSource sfxAudioSource;
    public AudioSource musicAudioSource;
    
    //Singleton
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {

        sfxAudioSource = transform.Find("SFXSource").GetComponent<AudioSource>();
        musicAudioSource = transform.Find("MusicSource").GetComponent<AudioSource>();
        musicVolume = 1;
        sfxVolume = 1;

    }

    public void PlaySoundOneshot(SoundType sound, float volume = 1)
    {
        instance.sfxAudioSource.PlayOneShot(instance.soundList[(int)sound]);
    }

    public void PlaySound(SoundType sound, float pitch)
    {
        PlaySound(sound, sfxVolume, pitch);
    }


    public void PlaySound(SoundType sound, float volume = -99, float pitch = 1)
    {
        sfxAudioSource.clip = instance.soundList[(int)sound];
        if(volume == -99)
        {
            sfxAudioSource.volume = sfxVolume;
        }
        else
        {
            sfxAudioSource.volume = volume;
        }
        sfxAudioSource.pitch = pitch;
        instance.sfxAudioSource.Play();
    }

    public void PlayMusic(MusicType music, float volume = -99)
    {
        musicAudioSource.clip = instance.musicList[(int)music];
        if (volume == -99)
        {
            musicAudioSource.volume = musicVolume;
        }
        else
        {
            musicAudioSource.volume = volume;
        }
        instance.musicAudioSource.Play();
    }

    public void ChangeSFXVolume()
    {
        sfxAudioSource.volume = sfxVolume;
    }
    public void ChangeMusicVolume()
    {
        musicAudioSource.volume = musicVolume;
    }
}
