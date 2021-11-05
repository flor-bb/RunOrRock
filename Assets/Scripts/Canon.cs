using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{


    [SerializeField] private GameObject rocket;

    private int rocketCount = 8;
    private int salveCounter = 5;

    void Start()
    {
        StartCoroutine(DestroyCanon());

        StartCoroutine(SpawnRocket());
    }


    void Update()

    { 
         
     
    }

 

    private IEnumerator SpawnRocket()
    {
       
        for(int j = 0; j< salveCounter; j++)
        {

        
  
         for(int i = 0; i< rocketCount; i++)

         {
            

            Instantiate(rocket, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }


            yield return new WaitForSeconds(5f);
        }


    }

    private IEnumerator DestroyCanon()
    {

        //Destorys the canon
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);

    }
}
