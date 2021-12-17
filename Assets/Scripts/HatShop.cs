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

    private int zylinderPrice = 1;
    private int santaPrice = 1;
    private int magicianPrice = 1;
    private int frogPrice = 1;

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

        if (!isZylinderBought)
        {
            zylinderBought.SetActive(false);
            zylinderChecked.SetActive(false);
            zylinderLocked.SetActive(true);
        }else if (isZylinderChecked)
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
        if (!isSantaBought)
        {
            santaBought.SetActive(false);
            santaChecked.SetActive(false);
            santaLocked.SetActive(true);
        }
        if (!isMagicianBought)
        {
            magicianBought.SetActive(false);
            magicianChecked.SetActive(false);
            magicianLocked.SetActive(true);
        }
        if (!isFrogBought)
        {
            frogBought.SetActive(false);
            frogChecked.SetActive(false);
            frogLocked.SetActive(true);
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
  
        }
    }

    public void CheckZylinder()
    {

        isZylinderChecked = true;
        PlayerPrefs.SetInt("isZylinderChecked", (isZylinderChecked ? 1 : 0));
        zylinderBought.SetActive(false);
        zylinderChecked.SetActive(true);
        zylinderLocked.SetActive(false);
        PlayerPrefs.SetInt("hatSelected", 0);
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
    }

}
