using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    [SerializeField] private Button helpButton;
    private int helpScore = 20;
    private int vulcanoScore = 23;
    private Image helpButtonImg;
    [SerializeField] private Text helpText;
    private int helpCounter = 0;
    [SerializeField] private GameObject alertScreen;
    private bool isAlert = true;

    private int selectedPlayer;

    private bool launchVolcano;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

            }
            return instance;
        }
    }

    public int score { get; set; }

    public int bestScore { get; set; }
    public int goldCount { get; set; }

    public Player player { get; private set; }

    private void Awake()
    {
       //  PlayerPrefs.DeleteAll();
        bestScore = PlayerPrefs.GetInt("BestScore");
        goldCount = PlayerPrefs.GetInt("GoldCount");


        instance = this;
        score = 0;
        if (helpButton != null)
        {


            helpButton.enabled = false;
            helpButtonImg = helpButton.GetComponent<Image>();
            helpText.enabled = false;
            helpButtonImg.enabled = false;
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }


    }

    private void Update()
    {
        UpdateAirSupport();
        UpdateVulcanoEruption();
        TrackBestScore();
    }

    private void UpdateVulcanoEruption()
    {

        if (score == vulcanoScore && isAlert)
        {
            isAlert = false;

            StartCoroutine(DelayVulcano());
            StartCoroutine(AlertSreenBlinker());
            FindObjectOfType<AudioManager>().Play("Alert");

            vulcanoScore = CalculateVulcanoScore(score);

        }
    }

    private void TrackBestScore()
    {

        if (score >= bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

    }


    private void UpdateAirSupport()
    {
        if (score == helpScore)
        {
            helpCounter++;
            if (helpButton != null)
            {
                helpButton.enabled = true;
                helpText.enabled = true;
                helpButtonImg.enabled = true;
                helpText.text = helpCounter + "x";
                helpScore = calculateHelpScore(score);
            }
        }

        if (helpCounter <= 0)
        {
            if (helpButton != null)
            {
                helpButton.enabled = false;
                helpText.enabled = false;
                helpButtonImg.enabled = false;
            }
        }
        if (helpText != null)
        {
            helpText.text = helpCounter + "x";
        }

    }

    public int getHelpCounter()
    {
        return this.helpCounter;
    }

    public void setHelpCounter(int x)
    {
        this.helpCounter = x;
    }


    private int calculateHelpScore(int x)
    {

        int y = Random.Range(30, 40);

        if (score <= 100)
        {
            return x += score + y;

        }
        else
        {
            return x += (score / 2) + y;
        }



    }

    private int CalculateVulcanoScore(int x)
    {

        int y = Random.Range(40, 55);

        if (score <= 100)
        {
            return x += score + y;

        }
        else
        {
            return x += (score / 2) + y;
        }

    }


    IEnumerator AlertSreenBlinker()

    {
        for (int i = 0; i < 3; i++)
        {
            if (alertScreen != null)
            {


                alertScreen.SetActive(true);

                yield return new WaitForSeconds(1f);

                alertScreen.SetActive(false);

                yield return new WaitForSeconds(1f);
                if (i == 2)
                {
                    isAlert = true;
                    score++;
                }
            }
        }


    }

    public void SetLaunchVolcano(bool launchVolcano)
    {
        this.launchVolcano = launchVolcano;
    }

    public bool GetLaunchVolcano()
    {
        return this.launchVolcano;
    }

    IEnumerator DelayVulcano()

    {


        yield return new WaitForSeconds(4f);
        SetLaunchVolcano(true);



    }

}