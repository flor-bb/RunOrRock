using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{

    [SerializeField] private GameObject bird;
    private int scoreChecker = 5;
    private int delayedBird = 50;

    void Start()
    {

    }

    void Update()
    {
        SpawnBird();
        SpawnDelayedBird();
    }

    private void SpawnBird()
    {
        if (GameManager.Instance.score == scoreChecker)
        {
            Instantiate(bird, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            scoreChecker += RandomScoreIncrease();
            Debug.Log("Next Bird at: " + scoreChecker);
        }

    }

    //This method is called when no bird is comming anymore
    //happens when the score is high
    private void SpawnDelayedBird()
    {

        if (GameManager.Instance.score == delayedBird || GameManager.Instance.score == delayedBird + 1)
        {
            scoreChecker = (delayedBird + 10);

            delayedBird += 50;
        }
    }



    private int RandomScoreIncrease()
    {
        int x = Random.Range(8, 14);

        return x;
    }




}
