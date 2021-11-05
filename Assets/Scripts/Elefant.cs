using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elefant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyElefant());

    }

    private IEnumerator DestroyElefant()
    {

        //Destorys the canon
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);

    }
}
