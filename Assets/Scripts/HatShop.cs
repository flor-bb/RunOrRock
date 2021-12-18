using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatShop : MonoBehaviour
{


    [SerializeField] private GameObject zylinderLocked;
    [SerializeField] private GameObject zylinderBought;
    [SerializeField] private GameObject zylinderChecked;
    [SerializeField] private GameObject santaLocked;
    [SerializeField] private GameObject santaBought;
    [SerializeField] private GameObject santaChecked;
    [SerializeField] private GameObject magicianLocked;
    [SerializeField] private GameObject magicianBought;
    [SerializeField] private GameObject magicianChecked;
    [SerializeField] private GameObject frogLocked;
    [SerializeField] private GameObject frogBought;
    [SerializeField] private GameObject frogChecked;
    [SerializeField] private Text goldCount;
    [SerializeField] private Text zylinderCostText;
    [SerializeField] private Text santaCostText;
    [SerializeField] private Text magicianCostText;
    [SerializeField] private Text frogCostText;

    private int zylinderPrice = 100;
    private int santaPrice = 500;
    private int magicianPrice = 1000;
    private int frogPrice = 5000;

    private bool isZylinderBought = false;
    private bool isZylinderChecked = false;
    private bool isSantaBought = false;
    private bool isSantaChecked = false;
    private bool isMagicianBought = false;
    private bool isMagicianChecked = false;
    private bool isFrogBought = false;
    private bool isFrogChecked = false;

    void Start()
    {
        RegisterBools();
        SetUpShop();
    }


    void Update()
    {

    }

    private void RegisterBools()
    {

        if ((PlayerPrefs.GetInt("isZylinderBought") != 0))
        {
            isZylinderBought = true;
        }

        if ((PlayerPrefs.GetInt("isZylinderChecked") != 0))
        {
            isZylinderChecked = true;
        }

        if ((PlayerPrefs.GetInt("isSantaBought") != 0))
        {
            isSantaBought = true;
        }

        if ((PlayerPrefs.GetInt("isSantaChecked") != 0))
        {
            isSantaChecked = true;
        }

        if ((PlayerPrefs.GetInt("isMagicianBought") != 0))
        {
            isMagicianBought = true;
        }
        if ((PlayerPrefs.GetInt("isMagicianChecked") != 0))
        {
            isMagicianChecked = true;
        }

        if ((PlayerPrefs.GetInt("isFrogBought") != 0))
        {
            isFrogBought = true;
        }
        if ((PlayerPrefs.GetInt("isFrogChecked") != 0))
        {
            isFrogChecked = true;
        }

    }


    private void SetUpShop()
    {
        goldCount.text = GameManager.Instance.goldCount.ToString();
        zylinderCostText.text = "Price: " + zylinderPrice.ToString();
        santaCostText.text = "Price: " + santaPrice.ToString();
        magicianCostText.text = "Price: " + magicianPrice.ToString();
        frogCostText.text = "Price: " + frogPrice.ToString();


        //Zylinder Button
        if (!isZylinderBought)
        {
            zylinderBought.SetActive(false);
            zylinderChecked.SetActive(false);
            zylinderLocked.SetActive(true);
        }
        else if (isZylinderChecked)
        {
            zylinderBought.SetActive(false);
            zylinderChecked.SetActive(true);
            zylinderLocked.SetActive(false);
            zylinderCostText.text = "";
        }
        else
        {
            zylinderBought.SetActive(true);
            zylinderChecked.SetActive(false);
            zylinderLocked.SetActive(false);
            zylinderCostText.text = "";
        }

        //santa Button
        if (!isSantaBought)
        {
            santaBought.SetActive(false);
            santaChecked.SetActive(false);
            santaLocked.SetActive(true);
        }
        else if (isSantaChecked)
        {
            santaBought.SetActive(false);
            santaChecked.SetActive(true);
            santaLocked.SetActive(false);
            santaCostText.text = "";
        }
        else
        {
            santaBought.SetActive(true);
            santaChecked.SetActive(false);
            santaLocked.SetActive(false);
            santaCostText.text = "";
        }

        //Magician Button
        if (!isMagicianBought)
        {
            magicianBought.SetActive(false);
            magicianChecked.SetActive(false);
            magicianLocked.SetActive(true);
        }
        else if (isMagicianChecked)
        {
            magicianBought.SetActive(false);
            magicianChecked.SetActive(true);
            magicianLocked.SetActive(false);
            magicianCostText.text = "";

        }
        else
        {
            magicianBought.SetActive(true);
            magicianChecked.SetActive(false);
            magicianLocked.SetActive(false);
            magicianCostText.text = "";
        }

        //Frog Button
        if (!isFrogBought)
        {
            frogBought.SetActive(false);
            frogChecked.SetActive(false);
            frogLocked.SetActive(true);
        }
        else if (isFrogChecked)
        {
            frogBought.SetActive(false);
            frogChecked.SetActive(true);
            frogLocked.SetActive(false);
            frogCostText.text = "";
        }
        else
        {
            frogBought.SetActive(true);
            frogChecked.SetActive(false);
            frogLocked.SetActive(false);
            frogCostText.text = "";
        }

    }


    public void BuyZylinder()
    {
        if (GameManager.Instance.goldCount >= zylinderPrice)
        {
            isZylinderBought = true;
            PlayerPrefs.SetInt("isZylinderBought", (isZylinderBought ? 1 : 0));
            zylinderBought.SetActive(true);
            zylinderChecked.SetActive(false);
            zylinderLocked.SetActive(false);
            zylinderCostText.text = "";
            GameManager.Instance.goldCount -= zylinderPrice;
            PlayerPrefs.SetInt("GoldCount", GameManager.Instance.goldCount);
            goldCount.text = GameManager.Instance.goldCount.ToString();
            FindObjectOfType<AudioManager>().Play("Coin");

        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Denied");
        }
    }

    public void CheckZylinder()
    {
        if (isZylinderBought)
        {
            isZylinderChecked = true;
            PlayerPrefs.SetInt("isZylinderChecked", (isZylinderChecked ? 1 : 0));
            zylinderBought.SetActive(false);
            zylinderChecked.SetActive(true);
            zylinderLocked.SetActive(false);
            PlayerPrefs.SetInt("hatSelected", 1);
            FindObjectOfType<AudioManager>().Play("RestartGame");
            if (isMagicianChecked)
            {
                magicianChecked.SetActive(false);
                magicianBought.SetActive(true);
                isMagicianChecked = false;
                PlayerPrefs.SetInt("isMagicianChecked", (isMagicianChecked ? 1 : 0));
            }
            if (isSantaChecked)
            {
                santaChecked.SetActive(false);
                santaBought.SetActive(true);
                isSantaChecked = false;
                PlayerPrefs.SetInt("isSantaChecked", (isSantaChecked ? 1 : 0));
            }
            if (isFrogChecked)
            {
                frogChecked.SetActive(false);
                frogBought.SetActive(true);
                isFrogChecked = false;
                PlayerPrefs.SetInt("isFrogChecked", (isFrogChecked ? 1 : 0));
            }

        }

    }

    public void UncheckZylinder()
    {
        isZylinderChecked = false;
        PlayerPrefs.SetInt("isZylinderChecked", (isZylinderChecked ? 1 : 0));
        isZylinderBought = true;
        PlayerPrefs.SetInt("isZylinderBought", (isZylinderBought ? 1 : 0));
        zylinderBought.SetActive(true);
        zylinderChecked.SetActive(false);
        zylinderLocked.SetActive(false);
        PlayerPrefs.SetInt("hatSelected", 100);
        FindObjectOfType<AudioManager>().Play("RestartGame");
    }

    public void BuySanta()
    {

        if (GameManager.Instance.goldCount >= santaPrice)
        {
            isSantaBought = true;
            PlayerPrefs.SetInt("isSantaBought", (isSantaBought ? 1 : 0));
            santaBought.SetActive(true);
            santaLocked.SetActive(false);
            santaChecked.SetActive(false);
            santaCostText.text = "";
            GameManager.Instance.goldCount -= santaPrice;
            PlayerPrefs.SetInt("GoldCount", GameManager.Instance.goldCount);
            goldCount.text = GameManager.Instance.goldCount.ToString();
            FindObjectOfType<AudioManager>().Play("Coin");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Denied");
        }

    }

    public void CheckSanta()
    {

        if (isSantaBought)
        {
            isSantaChecked = true;
            PlayerPrefs.SetInt("isSantaChecked", (isSantaChecked ? 1 : 0));
            santaBought.SetActive(false);
            santaChecked.SetActive(true);
            santaLocked.SetActive(false);
            PlayerPrefs.SetInt("hatSelected", 2);
            FindObjectOfType<AudioManager>().Play("RestartGame");
            if (isMagicianChecked)
            {
                magicianChecked.SetActive(false);
                magicianBought.SetActive(true);
                isMagicianChecked = false;
                PlayerPrefs.SetInt("isMagicianChecked", (isMagicianChecked ? 1 : 0));
            }
            if (isZylinderChecked)
            {
                zylinderChecked.SetActive(false);
                zylinderBought.SetActive(true);
                isZylinderChecked = false;
                PlayerPrefs.SetInt("isZylinderChecked", (isZylinderChecked ? 1 : 0));
            }
            if (isFrogChecked)
            {
                frogChecked.SetActive(false);
                frogBought.SetActive(true);
                isFrogChecked = false;
                PlayerPrefs.SetInt("isFrogChecked", (isFrogChecked ? 1 : 0));
            }

        }

    }

    public void UncheckSanta()
    {
        isSantaChecked = false;
        PlayerPrefs.SetInt("isSantaChecked", (isSantaChecked ? 1 : 0));
        isSantaBought = true;
        PlayerPrefs.SetInt("isSantaBought", (isSantaBought ? 1 : 0));
        santaBought.SetActive(true);
        santaChecked.SetActive(false);
        santaLocked.SetActive(false);
        PlayerPrefs.SetInt("hatSelected", 100);
        FindObjectOfType<AudioManager>().Play("RestartGame");

    }

    public void BuyMagician()
    {
        if (GameManager.Instance.goldCount >= magicianPrice)
        {
            isMagicianBought = true;
            PlayerPrefs.SetInt("isMagicianBought", (isMagicianBought ? 1 : 0));
            magicianBought.SetActive(true);
            magicianLocked.SetActive(false);
            magicianChecked.SetActive(false);
            magicianCostText.text = "";
            GameManager.Instance.goldCount -= magicianPrice;
            PlayerPrefs.SetInt("GoldCount", GameManager.Instance.goldCount);
            goldCount.text = GameManager.Instance.goldCount.ToString();
            FindObjectOfType<AudioManager>().Play("Coin");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Denied");
        }

    }

    public void CheckMagician()
    {

        if (isMagicianBought)
        {
            isMagicianChecked = true;
            PlayerPrefs.SetInt("isMagicianChecked", (isMagicianChecked ? 1 : 0));
            magicianBought.SetActive(false);
            magicianChecked.SetActive(true);
            magicianLocked.SetActive(false);
            PlayerPrefs.SetInt("hatSelected", 3);
            FindObjectOfType<AudioManager>().Play("RestartGame");
            if (isSantaChecked)
            {
                santaChecked.SetActive(false);
                santaBought.SetActive(true);
                isSantaChecked = false;
                PlayerPrefs.SetInt("isSantaChecked", (isSantaChecked ? 1 : 0));
            }
            if (isZylinderChecked)
            {
                zylinderChecked.SetActive(false);
                zylinderBought.SetActive(true);
                isZylinderChecked = false;
                PlayerPrefs.SetInt("isZylinderChecked", (isZylinderChecked ? 1 : 0));
            }
            if (isFrogChecked)
            {
                frogChecked.SetActive(false);
                frogBought.SetActive(true);
                isFrogChecked = false;
                PlayerPrefs.SetInt("isFrogChecked", (isFrogChecked ? 1 : 0));
            }

        }

    }

    public void UncheckMagician()
    {

        isMagicianChecked = false;
        PlayerPrefs.SetInt("isMagicianChecked", (isMagicianChecked ? 1 : 0));
        isMagicianBought = true;
        PlayerPrefs.SetInt("isMagicianBought", (isMagicianBought ? 1 : 0));
        magicianBought.SetActive(true);
        magicianChecked.SetActive(false);
        magicianLocked.SetActive(false);
        PlayerPrefs.SetInt("hatSelected", 100);
        FindObjectOfType<AudioManager>().Play("RestartGame");

    }


    public void BuyFrog()
    {
        if (GameManager.Instance.goldCount >= frogPrice)
        {
            isFrogBought = true;
            PlayerPrefs.SetInt("isFrogBought", (isFrogBought ? 1 : 0));
            frogBought.SetActive(true);
            frogLocked.SetActive(false);
            frogChecked.SetActive(false);
            frogCostText.text = "";
            GameManager.Instance.goldCount -= frogPrice;
            PlayerPrefs.SetInt("GoldCount", GameManager.Instance.goldCount);
            goldCount.text = GameManager.Instance.goldCount.ToString();
            FindObjectOfType<AudioManager>().Play("Coin");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Denied");
        }

    }

    public void CheckFrog()
    {

        if (isFrogBought)
        {
            isFrogChecked = true;
            PlayerPrefs.SetInt("isFrogChecked", (isFrogChecked ? 1 : 0));
            frogBought.SetActive(false);
            frogChecked.SetActive(true);
            frogLocked.SetActive(false);
            PlayerPrefs.SetInt("hatSelected", 4);
            FindObjectOfType<AudioManager>().Play("RestartGame");
            if (isSantaChecked)
            {
                santaChecked.SetActive(false);
                santaBought.SetActive(true);
                isSantaChecked = false;
                PlayerPrefs.SetInt("isSantaChecked", (isSantaChecked ? 1 : 0));
            }
            if (isZylinderChecked)
            {
                zylinderChecked.SetActive(false);
                zylinderBought.SetActive(true);
                isZylinderChecked = false;
                PlayerPrefs.SetInt("isZylinderChecked", (isZylinderChecked ? 1 : 0));
            }
            if (isMagicianChecked)
            {
                magicianChecked.SetActive(false);
                magicianBought.SetActive(true);
                isMagicianChecked = false;
                PlayerPrefs.SetInt("isMagicianChecked", (isMagicianChecked ? 1 : 0));
            }

        }

    }

    public void UncheckFrog()
    {

        isFrogChecked = false;
        PlayerPrefs.SetInt("isFrogChecked", (isFrogChecked ? 1 : 0));
        isFrogBought = true;
        PlayerPrefs.SetInt("isFrogBought", (isFrogBought ? 1 : 0));
        frogBought.SetActive(true);
        frogChecked.SetActive(false);
        frogLocked.SetActive(false);
        PlayerPrefs.SetInt("hatSelected", 100);
        FindObjectOfType<AudioManager>().Play("RestartGame");

    }





}
