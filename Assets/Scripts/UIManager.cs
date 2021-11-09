using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
      public Text  livesText;
    public GameObject gameOverScreen;

    //Singleton class
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UI Manager is null");
            }
            return instance;

        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdateTexts();
    }


    private void UpdateTexts()
    {

        if(scoreText!= null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score;

        }
        if(livesText!= null)
        {
            livesText.text = "Lives: " + GameManager.Instance.player.health;
        }
        

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        if(gameOverScreen!= null)
        {
            gameOverScreen.SetActive(false);
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {

    
            Application.Quit();
   
    }

}
