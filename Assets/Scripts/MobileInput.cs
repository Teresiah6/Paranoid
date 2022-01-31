using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private const float DEADZONE = 100.0f; // feel free to reduce accordingly
    public static MobileInput Instance { set; get; }
    private bool swipeLeft, swipeRight, tap;
    private Vector2 swipeDelta, startTouch;

    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public Vector2 SwipeDelta {get { return swipeDelta; } }
    public bool Tap { get { return tap; } }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tap=swipeLeft = swipeRight = false;

        //mobile inputs
        if(Input.touches[0].phase == TouchPhase.Began)
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
        {
            startTouch = swipeDelta = Vector2.zero;
        }
        //distance calculation 
        if(Input.touches.Length != 0)
        {
            swipeDelta = Input.touches[0].position - startTouch;
        }
        
        //check beyond deadzone
        if(swipeDelta.magnitude > DEADZONE)
        {
            //confirmed swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right swipe
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }

        }
    }
}
