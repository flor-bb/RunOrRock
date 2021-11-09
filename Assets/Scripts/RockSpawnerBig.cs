using System.Collections;
using UnityEngine;

public class RockSpawnerBig : MonoBehaviour
{


    public GameObject rock;
    private int spawnDelay;




    // Start is called before the first frame update
    void Start()
    {



        StartCoroutine(SpawnRock());


    }

    private void FixedUpdate()
    {

    }


    private IEnumerator SpawnRock()
    {
        while (true)
        {
            Instantiate(rock, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            spawnDelay = RandomSpawnDelay();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private int RandomSpawnDelay()
    {
        int x;

        if (GameManager.Instance.score <= 20)
        {
            x = Random.Range(8, 16);

        }
        else if (GameManager.Instance.score > 20 && GameManager.Instance.score <= 30)
        {
            x = Random.Range(7, 15);
        }
        else if (GameManager.Instance.score > 30 && GameManager.Instance.score <= 40)
        {
            x = Random.Range(6, 14);
        }
        else if (GameManager.Instance.score > 40 && GameManager.Instance.score <= 50)
        {
            x = Random.Range(5, 13);
        }
        else if (GameManager.Instance.score > 50 && GameManager.Instance.score <= 60)
        {
            x = Random.Range(4, 12);
        }
        else if (GameManager.Instance.score > 60 && GameManager.Instance.score <= 70)
        {
            x = Random.Range(3, 11);
        }
        else if (GameManager.Instance.score > 70 && GameManager.Instance.score <= 80)
        {
            x = Random.Range(2, 10);
        }
        else if (GameManager.Instance.score > 80 && GameManager.Instance.score <= 90)
        {
            x = Random.Range(1, 9);
        }
        else if (GameManager.Instance.score > 90 && GameManager.Instance.score <= 100)
        {
            x = Random.Range(2, 6);
        }
        else
        {
            x = Random.Range(1, 4);
        }

        return x;
    }



}
