using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{


    private Animator anim;

    void Start()
    {

        StartCoroutine(DestroyShield());
        FindObjectOfType<AudioManager>().Play("Shield");
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        anim = GetComponentInChildren<Animator>();
    }


    private void UpdatePosition()
    {


        transform.position = GameManager.Instance.player.transform.position;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rock")
        {

            Animator otherAnim = collision.GetComponent<Animator>();
            Rigidbody2D otherRB = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(WaitForExplosion(otherAnim, collision.gameObject, otherRB));
            GameManager.Instance.score++;

        }
    }

    private IEnumerator DestroyShield()
    {

        yield return new WaitForSeconds(12);
        anim.SetTrigger("Alert");



        //Destorys the canon
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        FindObjectOfType<AudioManager>().Stop("Shield");

    }

    IEnumerator WaitForExplosion(Animator anim, GameObject other, Rigidbody2D rb)
    {
        
        rb.velocity = Vector3.zero;
        anim.SetTrigger("Explode");
        FindObjectOfType<AudioManager>().Play("RockExplosion");
        //Wait for 4 seconds
        yield return new WaitForSeconds(0.5f);
        Destroy(other);

    }


}
