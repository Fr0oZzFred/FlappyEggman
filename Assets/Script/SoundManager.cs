using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainMenuTheme;
    public AudioSource inGameTheme;
    public AudioSource gameOverTheme;
    public AudioSource ringFallingSound;
    private static SoundManager _instance;
    public static SoundManager instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void PlayMenuTheme()
    {
        if(gameOverTheme.isPlaying)
        {
            gameOverTheme.Stop();
        }
        mainMenuTheme.Play();
    }

    public void PlayIGTheme()
    {
        if(mainMenuTheme.isPlaying)
        {
            mainMenuTheme.Stop();
        }
        inGameTheme.Play();
    }

    public void PlayGameOver()
    {
        if(inGameTheme.isPlaying)
        {
            inGameTheme.Stop();
        }
        gameOverTheme.Play();
    }
}
