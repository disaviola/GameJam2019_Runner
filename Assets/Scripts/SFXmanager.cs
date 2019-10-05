using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public static SFXmanager SFXIntsance;
    private AudioSource audioSource;

    public AudioClip Suck;
    public AudioClip Boink;


    private void Awake()
    {
        if(SFXIntsance == null)
        {
            SFXIntsance = this;
        }

        if(SFXIntsance != this)
        {
            Destroy(gameObject);

        }
        
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();


    }

    public void PlaySuck()
    {
        audioSource.clip = Suck;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }

    public void PlayBoink()
    {
        audioSource.clip = Boink;
        audioSource.volume = 1.0f;
        audioSource.Play();
    }
}
