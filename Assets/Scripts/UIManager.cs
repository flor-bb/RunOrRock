using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    public Text livesText;
    public Text bestText;
    public Text goldText;
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

        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score;

        }
        if (livesText != null)
        {
            livesText.text = "Lives: " + GameManager.Instance.player.health;
        }
        if (bestText != null)
        {
            bestText.text = "Best: " + GameManager.Instance.bestScore;
        }
        if(goldText != null)
        {
            goldText.text = "Gold: " + GameManager.Instance.goldCount;
        }


    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<AudioManager>().Play("RestartGame");
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        FindObjectOfType<AudioManager>().Play("RestartGame");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<AudioManager>().Play("StartGame");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
        FindObjectOfType<AudioManager>().Play("RestartGame");
    }

    public void QuitGame()
    {

        FindObjectOfType<AudioManager>().Play("StartGame");
        Application.Quit();

    }

    public void Help()
    {

        FindObjectOfType<AudioManager>().Play("RestartGame");
        SceneManager.LoadScene("Help");

    }

}
