using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource,SFXSource;

    [Header("Music")]
    public AudioClip music;

    [Header("SFX")]
    public AudioClip pickWaste;
    public AudioClip correctWaste;
    public AudioClip notCorrectWaste;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        musicSource.clip = music;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
