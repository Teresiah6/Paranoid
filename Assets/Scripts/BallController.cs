using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

    public GameManager gameManager;
    public Rigidbody2D rigidbody2D;
    public float ballSpeed = 1;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public Vector2 inDirection;

    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;

    public AudioSource ballAudio;
    public AudioClip ballHit;
    public AudioClip ballBonus;

    public int blocks;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
       blocks = GameObject.FindGameObjectsWithTag("Block").Length;


        inDirection = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(inDirection * ballSpeed);



    }
    private void Update()
    {
        scoreText.text = score.ToString();
        if(blocks ==0)
        {
            LevelCompletedPanel.SetActive(true);
        }
        float yVelocity = rigidbody2D.velocity.y;
       /* if (yVelocity < 8 && yVelocity > -8 && yVelocity != 0)
        {
            if (yVelocity > -2)
            {
                rigidbody2D.velocity = new Vector2(0, 10);

            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, -10);

            }

            if (transform.position.y < -1.287 || transform.position.x < -8.936 || transform.position.x > 10.623)
            {

                //  UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
            }
        } */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.CompareTag("Wall"))
        {
            var contactPoint = collision.contacts[0].point;
            Vector2 ballLocation = transform.position;
            var inNormal = (ballLocation - contactPoint).normalized;
            inDirection = Vector2.Reflect(inDirection, inNormal);
            ballAudio.PlayOneShot(ballHit, 1.0f);

           
          //  var velX = rigidbody2D.velocity.x / 2 + collision.collider.attachedRigidbody.velocity.x / 3;
            
        }
        else if(collision.collider.tag == "Block")
        {
            
            Destroy(collision.gameObject);
            ballAudio.PlayOneShot(ballBonus, 1.0f);
            blocks--;

            //gameManager.blocks--;
           /* if(gameManager.blocks <= 0)
            {
                LevelCompletedPanel.SetActive(true);
                SceneManager.LoadScene("Level");
                Time.timeScale = 0;
            }*/

            score++;

        }
        // for level 2
        else if(collision.collider.CompareTag("BottomWall"))
        {
            Destroy(collision.gameObject);
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
          
        }
    }
    public void ResetBall()
    {
       rigidbody2D.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0,0);
        StartCoroutine(GoBall());
    }
    public IEnumerator GoBall()
    {
        yield return new WaitForSeconds(2);
        var randomNumber = Random.Range(0, 2);
        if(randomNumber <= 0.5)
        {
            rigidbody2D.AddForce(new Vector2(10, ballSpeed));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(-10, -ballSpeed));
        }

    }

   
}
