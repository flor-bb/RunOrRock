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
        speed = -5f;

    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }
}
