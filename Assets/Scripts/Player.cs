using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int points;

    private Rigidbody2D _rigid;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private LayerMask _groundLayer = 1<<8;
    private SpriteRenderer _playerSprite;
    protected Animator anim;
    private UIManager uiManager;
    public GameObject gameOverScreen;
    public GameObject scoreBarrier;
    [SerializeField] private GameObject canon;
    [SerializeField] private GameObject elefant;
    [SerializeField] private GameObject shield;

    public int health;



    void Start()
    {
        scoreBarrier.SetActive(true);
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
            if(health == 0)
            {
                Destroy(gameObject);
                gameOverScreen.SetActive(true);
                scoreBarrier.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "HealthItem")
        {
            health += 2;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "CanonItem")
        {
            Instantiate(canon, new Vector3(09.31f, -0.68f, transform.position.z), Quaternion.identity);
            Instantiate(elefant, new Vector3(11.1f, -0.63f, transform.position.z), Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ShieldItem")
        {
            Instantiate(shield, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(collision.gameObject);
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



