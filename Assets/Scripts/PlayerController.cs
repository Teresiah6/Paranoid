using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // public KeyCode moveRight, moveLeft;
    public float speed = 10.0f;
    public float MaxDrag = 5f;
    private Rigidbody2D rigidbody2D;
    Touch touch;
    Vector3 dragStartPos;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            touchPosition.y = -3.93f;
            transform.position = touchPosition;

            /*rigidbody2D.velocity = new Vector2(speed, 0);
        }
    else if (MobileInput.Instance.SwipeLeft)
        {
            rigidbody2D.velocity = new Vector2(-speed, 0);
        }
    else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    */
        }
    }
    void DragStart() {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
    }
    void Dragging() {

        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0;
    }
    void DragRelease() {
    
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;
        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, MaxDrag) * speed;

        rigidbody2D.AddForce(clampedForce,ForceMode2D.Impulse);
    }
}
