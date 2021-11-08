using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Rigidbody2D _rigid;
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private GameObject healthPack;
    [SerializeField] private GameObject canonPack;
    [SerializeField] private GameObject shieldPack;
    private bool spawnItem= true;
    private int spawnPoint;
    private int choosenItem;

    void Start()
    {

        _rigid = GetComponent<Rigidbody2D>();
        spawnPoint = RandomItemSpawnPoint();
        choosenItem = RandomItemChooser();
    }


    void Update()
    {

        _rigid.velocity = new Vector2(_speed, _rigid.velocity.y);
        SpawnItems();

        Debug.Log(RandomItemChooser());
    }

    private void SpawnItems()
    {

        if(transform.position.x >= spawnPoint && spawnItem)
        {
            switch (choosenItem)
            {
                case 1:
                    Instantiate(healthPack, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    spawnPoint = RandomItemSpawnPoint();
                    choosenItem = RandomItemChooser();
                    spawnItem = false;

                    break;

                case 2:
                    Instantiate(canonPack, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    spawnPoint = RandomItemSpawnPoint();
                    choosenItem = RandomItemChooser();
                    spawnItem = false;

                    break;

                case 3:
     
                    Instantiate(shieldPack, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    spawnPoint = RandomItemSpawnPoint();
                    choosenItem = RandomItemChooser();
                    spawnItem = false;

                    break;

                default:

                    break;

            }
       
            
        }

    }


    private int RandomItemSpawnPoint()
    {
        int x = Random.Range(-5, 5);

        return x;
    }


    private int RandomItemChooser()
    {
        int x = Random.Range(1, 4);

        return x;
    }
}
