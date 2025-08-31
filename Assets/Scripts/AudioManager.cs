using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    public static AudioManager Instance;

    [Header("UI Sounds")]
    public AudioClip buttonClick;

    [Header("Card Sounds")]
    public AudioClip flipCard;
    public AudioClip matchCard;
    public AudioClip mismatchCard;

    [Header("Game Sounds")]
    public AudioClip gameOver;
    public AudioClip splashScreen;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton → only one AudioManager in the game
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
{
    if (clip != null && audioSource != null)
        audioSource.PlayOneShot(clip);
    else
        Debug.LogWarning("⚠️ Missing AudioClip or AudioSource in AudioManager!");
}

}

