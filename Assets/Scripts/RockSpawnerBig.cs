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
        int x = Random.Range(2, 6);

        return x;
    }



}
