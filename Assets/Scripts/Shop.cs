using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    [SerializeField] GameObject giraffeLocked;
    [SerializeField] GameObject giraffeBought;
    [SerializeField] GameObject giraffeChecked;
    [SerializeField] GameObject lamaChecked;
    [SerializeField] GameObject lamaBought;




    void Start()
    {
        giraffeLocked.SetActive(true);
        giraffeBought.SetActive(false);
        giraffeChecked.SetActive(false);
        lamaChecked.SetActive(true);
        lamaBought.SetActive(false);

    }


    void Update()
    {

    }
}
