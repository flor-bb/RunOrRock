using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    [SerializeField] private Button helpButton;
    private int helpScore = 0;
    private Image helpButtonImg;
   [SerializeField] private Text helpText;

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
        
        if(score >= helpScore)
        {

        }


    }

    private void DoNothing()
    {

    }

}