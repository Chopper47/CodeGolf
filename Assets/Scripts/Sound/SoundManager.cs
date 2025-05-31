using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum SoundType
{
    HITBALL,
    BUTTONCLICK,

}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;

    public float musicVolume { get; set; }
    public float sfxVolume { get; set; }

    public static SoundManager instance;
    private AudioSource audioSource;
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
        
        audioSource = GetComponent<AudioSource>();
        musicVolume = 1;
        sfxVolume = 1;

    }

    public void PlaySoundOneshot(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound]);
    }

    public void PlaySound(SoundType sound, float pitch)
    {
        PlaySound(sound, sfxVolume, pitch);
    }


    public void PlaySound(SoundType sound, float volume = -99, float pitch = 1)
    {
        audioSource.clip = instance.soundList[(int)sound];
        if(volume == -99)
        {
            audioSource.volume = sfxVolume;
        }
        else
        {
            audioSource.volume = volume;
        }
        audioSource.pitch = pitch;
        instance.audioSource.Play();
    }
}
