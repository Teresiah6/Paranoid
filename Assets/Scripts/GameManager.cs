using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Transform theBall;
    static int gameScore;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }
    public static void Score(string WallName)
    {
        if (WallName == "BottomWall")
        {
            gameScore++;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
