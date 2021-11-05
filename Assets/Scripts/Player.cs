using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int points;

    private Rigidbody2D _rigid;
    private bool _resetJump = false;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private LayerMask _groundLayer = 1<<8;
    private SpriteRenderer _playerSprite;
    protected Animator anim;
    private UIManager uiManager;
    public GameObject gameOverScreen;

    public int health;



    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
 
        _playerSprite = GetComponentInChildren<SpriteRenderer>();

        health = 3;
        uiManager = UIManager.Instance;
      
    }

    void Update()
    {

        Movement();

    }

    private void Movement()
    {

    
        float move = CrossPlatformInputManager.GetAxis("Horizontal");  //Input.GetAxisRaw("Horizontal");

        Flip(move);

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        anim.SetFloat("Move", Mathf.Abs(move));

    }

    private void Flip(float move)
    {
        if (move > 0)
        {
            //flips the player
            _playerSprite.flipX = false;


        }
        else if (move < 0)
        {
            //flips the player
            _playerSprite.flipX = true;
          
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            health--;
            Destroy(collision.gameObject);
            if(health == 0)
            {
                Destroy(gameObject);
                gameOverScreen.SetActive(true);

            }
        }
    }


    public void Damage()
    {

        if (health <= 0)
        {
            return;
        }
        health--;
 

        if (health <= 0)
        {



            StartCoroutine(waitForMainMenu());

            

        }
       
    }

    public void AddGems(int amount)
    {
        points += amount;
 
    }


    IEnumerator waitForMainMenu()
    {

        //Wait for 4 seconds
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main_Menu");

    }
}



