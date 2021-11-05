using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{

    [SerializeField] private GameObject bird;
    private int scoreChecker =5;


    void Start()
    {
        
    }

    void Update()
    {
        SpawnBird();
    }

    private void SpawnBird()
    {
        if (GameManager.Instance.score == scoreChecker)
        {
            Instantiate(bird, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            scoreChecker += RandomScoreIncrease();
        }
    }


    private int RandomScoreIncrease()
    {
        int x = Random.Range(5, 20);

        return x;
    }




}
