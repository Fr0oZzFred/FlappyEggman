using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int addScore = 1;
    public int score = 0;
    public enum GameState
    {
        Start,
        InGame,
        Pause,
        Death,
    }

    private static GameState _gameState;

    public static GameState gameState
    {
        get
        {
            return _gameState;
        }
    }

    private static GameManager _instance;
    public static GameManager instance
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

    private void Start()
    {
        ChangeGameState(GameState.Start);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (gameState == GameState.InGame ||gameState == GameState.Pause))
        {
            Pause();
        }
    }

    public void ChangeGameState(GameState newState)
    {
        _gameState = newState;
        switch(_gameState)
        {
            case GameState.Start:
                SoundManager.instance.PlayMenuTheme();
                UIManager.instance.AffichageMainMenu();
                Time.timeScale = 0;
                break;

            case GameState.InGame:
                SoundManager.instance.inGameTheme.UnPause();
                if (!SoundManager.instance.inGameTheme.isPlaying)
                {
                    SoundManager.instance.PlayIGTheme();
                }
                UIManager.instance.AffichageMenuPause();
                UIManager.instance.AffichageMainMenu();
                Time.timeScale = 1;
                break;

            case GameState.Pause:
                SoundManager.instance.inGameTheme.Pause();
                UIManager.instance.AffichageMenuPause();
                break;

            case GameState.Death:
                if(!SoundManager.instance.gameOverTheme.isPlaying)
                {
                    SoundManager.instance.PlayGameOver();
                    SoundManager.instance.ringFallingSound.Play();
                }
                UIManager.instance.AfficherGameOver();
                break;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        if (gameState != GameState.Pause)
        {
            ChangeGameState(GameState.Pause);
        }
        else
        {
            ChangeGameState(GameState.InGame);
        }
    }
}
