using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBird : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = -3f;
        FindObjectOfType<AudioManager>().Play("AirSupport");
        
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Rock")
        {
            Animator otherAnim = collision.GetComponent<Animator>();
            Rigidbody2D otherRB = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(waitForExplosion(otherAnim, collision.gameObject, otherRB));
            GameManager.Instance.score++;
    
        }

        if (collision.tag == "BirdBarrier")
        {

            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Stop("AirSupport");
        }

    }

    //let the Rock explode
    IEnumerator waitForExplosion(Animator anim, GameObject other, Rigidbody2D rb)
    {
        rb.velocity = Vector3.zero;
        anim.SetTrigger("Explode");
        FindObjectOfType<AudioManager>().Play("RockExplosion");
        //Wait for 4 seconds
        yield return new WaitForSeconds(0.5f);
        Destroy(other);

    }

}
