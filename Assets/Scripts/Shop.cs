using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    [SerializeField] private GameObject giraffeLocked;
    [SerializeField] private GameObject giraffeBought;
    [SerializeField] private GameObject giraffeChecked;
    [SerializeField] private GameObject lamaChecked;
    [SerializeField] private GameObject lamaBought;
    [SerializeField] private Text goldCount;
    [SerializeField] private Text giraffeCost;
    private int giraffePrice = 5000;

    private bool isGiraffeUnlocked = false;
    private bool isGiraffeSelected = false;
    private bool isLamaSelected = true;

    void Start()
    {

        SetUpShop();
        goldCount.text = GameManager.Instance.goldCount.ToString();
        if (isGiraffeUnlocked)
        {
            giraffeCost.text = "";
        }
        else
        {
            giraffeCost.text = "Price: " + giraffePrice.ToString();
        }

       // giraffeCost.text = "Price: " + giraffePrice.ToString();
    }


    void Update()
    {
        CheckGoldCountGiraffe();
    }

    private void SetUpShop()
    {

        if ((PlayerPrefs.GetInt("isGiraffeUnlocked") != 0))
        {
            isGiraffeUnlocked = true;
        }

        if ((PlayerPrefs.GetInt("isGiraffeSelected") != 0))
        {
            isGiraffeSelected = true;
        }

        if ((PlayerPrefs.GetInt("isLamaSelected") != 0))
        {
            isLamaSelected = true;
        }
        else
        {
            isLamaSelected = false;
        }

        if (!isGiraffeSelected)
        {
            isLamaSelected = true;
        }


        Debug.Log("Giraffe Selected? " + isGiraffeSelected);
        Debug.Log("Giraffe Bought? " + isGiraffeUnlocked);
        Debug.Log("Lama Selected? " + (PlayerPrefs.GetInt("isLamaSelected") != 0));


        if (isLamaSelected)
        {
            giraffeLocked.SetActive(true);
            giraffeBought.SetActive(false);
            giraffeChecked.SetActive(false);
            lamaChecked.SetActive(true);
            lamaBought.SetActive(false);
            Debug.Log("Lama is Selected");
        }


        if (isGiraffeUnlocked && !isGiraffeSelected && isLamaSelected)
        {
            giraffeLocked.SetActive(false);
            giraffeBought.SetActive(true);
            giraffeChecked.SetActive(false);
            lamaChecked.SetActive(true);
            lamaBought.SetActive(false);
            Debug.Log("Lama is Selected And Giraffe is bought");

        }

        if (!isLamaSelected && isGiraffeSelected)
        {
            giraffeLocked.SetActive(false);
            giraffeBought.SetActive(false);
            giraffeChecked.SetActive(true);
            lamaChecked.SetActive(false);
            lamaBought.SetActive(true);
            Debug.Log("Giraffe is selected");
        }


    }


    private void CheckGoldCountGiraffe()
    {
        if (GameManager.Instance.goldCount < giraffePrice)
        {
            giraffeLocked.GetComponent<Button>().enabled = false;
        }
        else
        {
            giraffeLocked.GetComponent<Button>().enabled = true;
        }
        goldCount.text = GameManager.Instance.goldCount.ToString();
    }

    public void BuyGiraffe()
    {
        if (GameManager.Instance.goldCount >= giraffePrice)
        {
            giraffeLocked.SetActive(false);
            giraffeBought.SetActive(true);
            isGiraffeUnlocked = true;
            PlayerPrefs.SetInt("isGiraffeUnlocked", (isGiraffeUnlocked ? 1 : 0));
            GameManager.Instance.goldCount -= giraffePrice;
            PlayerPrefs.SetInt("GoldCount", GameManager.Instance.goldCount);
            giraffeCost.text = "";
            FindObjectOfType<AudioManager>().Play("Coin");
        }

    }

    public void SelectGiraffe()
    {
        isGiraffeSelected = true;
        PlayerPrefs.SetInt("isGiraffeSelected", (isGiraffeSelected ? 1 : 0));
        isLamaSelected = false;
        PlayerPrefs.SetInt("isLamaSelected", (isLamaSelected ? 1 : 0));

        giraffeBought.SetActive(false);
        giraffeChecked.SetActive(true);
        lamaChecked.SetActive(false);
        lamaBought.SetActive(true);
        PlayerPrefs.SetInt("selectedPlayer", 1);
        FindObjectOfType<AudioManager>().Play("RestartGame");

    }

    public void SelectLama()
    {
        isLamaSelected = true;
        PlayerPrefs.SetInt("isLamaSelected", (isLamaSelected ? 1 : 0));
        isGiraffeSelected = false;
        PlayerPrefs.SetInt("isGiraffeSelected", (isGiraffeSelected ? 1 : 0));

        giraffeBought.SetActive(true);
        giraffeChecked.SetActive(false);
        lamaChecked.SetActive(true);
        lamaBought.SetActive(false);
        PlayerPrefs.SetInt("selectedPlayer", 0);
        FindObjectOfType<AudioManager>().Play("RestartGame");
    }

}