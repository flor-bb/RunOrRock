using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(FinishSplashScreen());
    }



    private IEnumerator FinishSplashScreen()
    {

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Main_Menu");

    }



}
