using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode moveRight, moveLeft;
    public float speed = 10.0f;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveRight))
        {
            rigidbody2D.velocity = new Vector2(speed, 0);
        }
        else if (Input.GetKey(moveLeft))
        {
            rigidbody2D.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
