using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text textScore;
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject menuPause;
    [SerializeField]
    GameObject menuGameOver;
    private static UIManager _instance;
    public static UIManager instance
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
    void Update()
    {
        textScore.text = "Score : " + GameManager.instance.score;
    }

    public void AddScore()
    {
        GameManager.instance.score += GameManager.instance.addScore;
    }

    public void AffichageMainMenu()
    {
        if(GameManager.gameState == GameManager.GameState.Start)
        {
            mainMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(false);
        }
    }
    public void AffichageMenuPause()
    {
        if (GameManager.gameState == GameManager.GameState.Pause)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void AfficherGameOver()
    {
        menuGameOver.SetActive(true);
    }
    
    public void Restart()
    {
        menuGameOver.SetActive(false);
        GameManager.instance.LoadScene();
        GameManager.instance.ChangeGameState(GameManager.GameState.Start);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
