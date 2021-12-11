using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{

    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;
    [SerializeField] private GameObject img3;
    [SerializeField] private GameObject img4;

    void Start()
    {
        StartCoroutine(FinishSplashScreen());

        img1.SetActive(true);
        img2.SetActive(false);
        img3.SetActive(false);
        img4.SetActive(false);
    }



    private IEnumerator FinishSplashScreen()
    {

        yield return new WaitForSeconds(0.5f);
        img1.SetActive(false);
        img2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        img2.SetActive(false);
        img3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        img3.SetActive(false);
        img4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        img4.SetActive(false);
        img1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        img1.SetActive(false);
        img2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        img2.SetActive(false);
        img3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        img3.SetActive(false);
        img4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Main_Menu");

    }



}
