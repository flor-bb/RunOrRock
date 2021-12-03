using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    protected Animator anim;
    protected BoxCollider2D boxCollider;
    private bool isCollected = false;
    private float x;
    private float y;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        y = -0.5f;
        x = Random.Range(-9f, 10.5f);
        boxCollider.enabled = false;

    }


    void Update()
    {
        if (isCollected)
        {
            Collected();
        }
        GoToRandomPosition();

    }

    private void GoToRandomPosition()
    {
        if (!isCollected)
        {
            Vector3 target = new Vector3(x, y, 0);
            float step = 15f * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if(transform.position == target)
            {
                boxCollider.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Collected");
            FindObjectOfType<AudioManager>().Play("Coin");
            isCollected = true;
        }
    }

    private void Collected()
    {
        float step = 20f * Time.deltaTime; // calculate distance to move
        Vector3 target = new Vector3(11.7f, 6.2f, 0);

        transform.position = Vector3.MoveTowards(transform.position, target, step);
        Explode(target);
    }

    private void Explode(Vector3 target)
    {
        if (transform.position == target)
        {
            anim.SetTrigger("Explode");
            StartCoroutine(WaitOnDestroy());
        }

    }


    IEnumerator WaitOnDestroy()
    {

        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.goldCount++;
        PlayerPrefs.SetInt("GoldCount", GameManager.Instance.goldCount);
        Destroy(this.gameObject);

    }


}
