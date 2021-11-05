using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

  
        if (collision.tag == "Rock")
        {
            GameManager.Instance.score++;

            Destroy(collision.gameObject);

       

        }
    }
}
