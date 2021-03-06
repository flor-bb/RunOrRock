using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speedX, randomSpeedY, randomRotateSpeed;
    [SerializeField] private GameObject coin;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("RocketLaunch");

        rb = gameObject.GetComponent<Rigidbody2D>();

        speedX = -7f;
        randomSpeedY = RandomSpawnDelay();

        rb.gravityScale = 0;
        rb.mass = 0;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rock")
        {

            Animator otherAnim = collision.GetComponent<Animator>();
            Rigidbody2D otherRB = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(waitForExplosion(otherAnim, collision.gameObject, otherRB));
            GameManager.Instance.score++;
            Destroy(gameObject);
        }

        if (collision.tag == "Score_Barrier")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speedX, randomSpeedY);
    }


    private float RandomSpawnDelay()
    {
        float x = Random.Range(0.3f, 4f);

        return x;
    }


    //let the Rock explode
    IEnumerator waitForExplosion(Animator anim, GameObject other, Rigidbody2D rb)
    {
        rb.velocity = Vector3.zero;
        anim.SetTrigger("Explode");
        FindObjectOfType<AudioManager>().Play("RockExplosion");
        Instantiate(coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);
        Destroy(other);

    }
}
