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

    public static SoundManager instance;
    private AudioSource audioSource;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

    }

    public void PlaySoundOneshot(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

    public void PlaySound(SoundType sound, float pitch)
    {
        PlaySound(sound, 1, pitch);
    }
    public void PlaySound(SoundType sound, float volume = 1, float pitch = 1)
    {
        audioSource.clip = instance.soundList[(int)sound];
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        instance.audioSource.Play();
    }
}
