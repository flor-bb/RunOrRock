using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{


    private Rigidbody2D rb;
    private float randomSpeedX, randomSpeedY, randomRotateSpeed;
    public GameObject indicator;
   private  GameObject tempIndicator;
    private Animator anim;

    void Start() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        randomSpeedX = RandomSpeedX();
        randomSpeedY = RandomSpeedY();
        randomRotateSpeed = RandomRotateSpeed();


        rb.AddForce(new Vector2(randomSpeedX, randomSpeedY));
        transform.Rotate(Vector3.right, randomRotateSpeed * Time.deltaTime, Space.World);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Ground"){


            if(randomSpeedX-200f <= 0f)
            {
                rb.AddForce(new Vector2(randomSpeedX, randomSpeedY - 200f));
            }
            else
            {
                rb.AddForce(new Vector2(randomSpeedX - 200f, randomSpeedY - 200f));
            }
      

        }

        if (collision.gameObject.tag == "Player")
        {



            StartCoroutine(waitForExplosion());



        }

    }

   

    IEnumerator waitForExplosion()
    {
        rb.velocity = Vector3.zero;
        anim.SetTrigger("Explode");
        //Wait for 4 seconds
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }




private float RandomSpeedX()
    {
       float x =  Random.Range(100f, 400f);

        return x;
    }


    private float RandomSpeedY()
    {
        float y = Random.Range(600f, 1500f);

        return y;
    }

    private float RandomRotateSpeed()
    {
        float r = Random.Range(500f, 600f);

        return r;
    }


    public void SpawnIndicator()
    {


        if(transform.position.y >= 7)
        {
            if (tempIndicator == null)
            {
                tempIndicator = Instantiate(indicator, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }

        
        }
        else if(transform.position.y <= 6)
        {
            if (tempIndicator != null)
            {
                Destroy(tempIndicator);
            }
        }

        if (tempIndicator != null)
        {
            tempIndicator.transform.position = transform.position;
        }
    }





    // Update is called once per frame
    void Update()
    {
        SpawnIndicator();

   

    }

    private void OnDestroy()
    {
        Destroy(tempIndicator);
    }
}
