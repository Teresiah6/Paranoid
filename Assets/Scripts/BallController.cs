using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public int ballSpeed = 10;
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        float yVelocity = rigidbody2D.velocity.y;
        if(yVelocity <8 && yVelocity >-8 && yVelocity !=0)
        {
            if(yVelocity > 0)
            {
                rigidbody2D.velocity = new Vector2(0, 10);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, -10);
            }

        }

      
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            var velX = rigidbody2D.velocity.x / 2 + collision.collider.attachedRigidbody.velocity.x / 3;


        }
        else if(collision.collider.tag == "Block")
        {
            Destroy(collision.gameObject);
            score++;

        }
        // for level 2
        else if(collision.collider.tag == "BottomWall")
        {
            Destroy(collision.gameObject);
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
