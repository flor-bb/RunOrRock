using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    [SerializeField] private Button helpButton;
    //TODO Change this later
    private int helpScore = 1;
    private int vulcanoScore = 2;
    private Image helpButtonImg;
    [SerializeField] private Text helpText;
    private int helpCounter = 0;
    [SerializeField] private GameObject alertScreen;
    private bool isAlert = true;

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

    public Player player { get; private set; }

    private void Awake()
    {
        instance = this;
        score = 0;
        helpButton.enabled = false;
        helpButtonImg = helpButton.GetComponent<Image>();
        helpText.enabled = false;
        helpButtonImg.enabled = false;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

    private void Update()
    {
        UpdateAirSupport();
        UpdateVulcanoEruption();
    }

    private void UpdateVulcanoEruption()
    {

        if (score == vulcanoScore && isAlert)
        {
            isAlert = false;


            StartCoroutine(AlertSreenBlinker());
            FindObjectOfType<AudioManager>().Play("Alert");

        }
    }




    private void UpdateAirSupport()
    {
        if (score == helpScore)
        {
            helpCounter++;
            helpButton.enabled = true;
            helpText.enabled = true;
            helpButtonImg.enabled = true;
            helpText.text = helpCounter + "x";

            helpScore = calculateHelpScore(score);
        }

        if (helpCounter <= 0)
        {
            helpButton.enabled = false;
            helpText.enabled = false;
            helpButtonImg.enabled = false;
        }

        helpText.text = helpCounter + "x";
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

    IEnumerator AlertSreenBlinker()

    {
        for (int i = 0; i < 3; i++)
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