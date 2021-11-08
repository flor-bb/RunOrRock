using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBirdSpawner : MonoBehaviour
{

    [SerializeField] private GameObject attackBird;
   
    void Start()
    {
     
    }


    public void SpawnAttackBirds()
    {
        Instantiate(attackBird, new Vector3(20, -0.93f, transform.position.z), Quaternion.identity);
        Instantiate(attackBird, new Vector3(20, 1.25f, transform.position.z), Quaternion.identity);
        Instantiate(attackBird, new Vector3(20, 3.4f, transform.position.z), Quaternion.identity);
        Instantiate(attackBird, new Vector3(20, 5.55f, transform.position.z), Quaternion.identity);
        Instantiate(attackBird, new Vector3(20, 7.7f, transform.position.z), Quaternion.identity);
        Instantiate(attackBird, new Vector3(20, 10.1f, transform.position.z), Quaternion.identity);
        Instantiate(attackBird, new Vector3(20, 12.38f, transform.position.z), Quaternion.identity);
        Instantiate(attackBird, new Vector3(20, 14.78f, transform.position.z), Quaternion.identity);
    }



}
