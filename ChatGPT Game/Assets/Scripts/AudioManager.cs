using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource; // the audio source component

    [Header("For Obstacles")]
    public bool isObstacle;
    public AudioClip[] audioClips; // an array of audio clips
    private int currentClipIndex; // the current audio clip index

    [Header("For Background")]
    public AudioClip backgroundSound; // the background sound
    public AudioClip gameOverSound; // the game over sound
    public bool isGameOver; // a flag to check if the game is over

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isGameOver = true;

        if (isGameOver && !isObstacle)
        {
            Restart();
        }

        if (isObstacle)
        {
            currentClipIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (isGameOver && !isObstacle && !PlayerMovement.instance.isPlayerAlive)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = false;
        audioSource.Stop();
        audioSource.clip = gameOverSound;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void Restart()
    {
        audioSource.Stop();
        audioSource.clip = backgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }
}
