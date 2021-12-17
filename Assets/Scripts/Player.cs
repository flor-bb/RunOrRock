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
    [SerializeField] private LayerMask _groundLayer = 1 << 8;
    private SpriteRenderer _playerSprite;
    protected Animator anim;
    private UIManager uiManager;
    public GameObject gameOverScreen;
    public GameObject scoreBarrier;
    [SerializeField] private GameObject canon;
    [SerializeField] private GameObject elefant;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject lama;
    [SerializeField] private GameObject giraffe;
    [SerializeField] private GameObject lamaZylinder, lamaFrog, lamaMagician, lamaSanta;
    [SerializeField] private GameObject giraffeZylinder, giraffeFrog, giraffeMagician, giraffeSanta;


    public int health;



    void Start()
    {

        if (PlayerPrefs.GetInt("selectedPlayer") == 0)
        {
            lama.SetActive(true);
            giraffe.SetActive(false);
            transform.localScale = new Vector3(1, 1, 0);

        }
        else if (PlayerPrefs.GetInt("selectedPlayer") == 1)
        {
            lama.SetActive(false);
            giraffe.SetActive(true);
            transform.localScale = new Vector3(1.3f, 1.3f, 0);
            _speed = 6f;


        }
        else
        {
            lama.SetActive(true);
            giraffe.SetActive(false);
            transform.localScale = new Vector3(1, 1, 0);

        }

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
            if (PlayerPrefs.GetInt("selectedPlayer") == 0)
            {
                _playerSprite.flipX = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            //reposition the hats
            //Zylinder
            lamaZylinder.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.95f, transform.position.z);
            lamaZylinder.transform.eulerAngles = new Vector3(0, 0, 18.1f);

            //Frog
            lamaFrog.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.95f, transform.position.z);
            lamaFrog.transform.eulerAngles = new Vector3(0, 0, 18.1f);
            lamaFrog.GetComponent<SpriteRenderer>().flipX = false;

            //Santa
            lamaSanta.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.6f, transform.position.z);
            lamaSanta.transform.eulerAngles = new Vector3(0, 0, 5f);
            lamaSanta.GetComponent<SpriteRenderer>().flipX = false;

            //macigian
            lamaMagician.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y + 1.05f, transform.position.z);
            lamaMagician.transform.eulerAngles = new Vector3(0, 0, 15f);
            lamaMagician.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (move < 0)
        {
            //flips the player
            if (PlayerPrefs.GetInt("selectedPlayer") == 0)
            {
                _playerSprite.flipX = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }

            //reposition the hats
            //Zylinder
            lamaZylinder.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.95f, transform.position.z);
            lamaZylinder.transform.eulerAngles = new Vector3(0, 0, 18.1f);


            //Frog
            lamaFrog.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y + 0.9f, transform.position.z);
            lamaFrog.transform.eulerAngles = new Vector3(0, 0, -26.405f);
            lamaFrog.GetComponent<SpriteRenderer>().flipX = true;



            //Santa
            lamaSanta.transform.position = new Vector3(transform.position.x - 0.25f, transform.position.y + 0.6f, transform.position.z);
            lamaSanta.transform.eulerAngles = new Vector3(0, 0, -3f);
            lamaSanta.GetComponent<SpriteRenderer>().flipX = true;



            //macigian
            lamaMagician.transform.position = new Vector3(transform.position.x - 0.25f, transform.position.y + 1.05f, transform.position.z);
            lamaMagician.transform.eulerAngles = new Vector3(0, 0, -10f);
            lamaMagician.GetComponent<SpriteRenderer>().flipX = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            health--;
            if (health == 0)
            {
                FindObjectOfType<AudioManager>().Play("GameOver");
                Destroy(gameObject);
                gameOverScreen.SetActive(true);
                scoreBarrier.SetActive(false);

            }
        }

        if (collision.gameObject.tag == "HealthItem")
        {
            health += 2;
            FindObjectOfType<AudioManager>().Play("ItemPickUp");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "CanonItem")
        {
            Instantiate(canon, new Vector3(09.31f, -0.68f, transform.position.z), Quaternion.identity);
            Instantiate(elefant, new Vector3(11.1f, -0.63f, transform.position.z), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("ItemPickUp");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ShieldItem")
        {
            Instantiate(shield, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("ItemPickUp");
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



