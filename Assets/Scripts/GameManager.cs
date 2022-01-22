using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    Transform theBall;
    static int gameScore;
    public  GameObject [] blocks;
    public GameObject[] childblocks;
    
   // public static int numberOfBlocksHit;
  //  public static int score = 0; 
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
       // numberOfBlocksHit = 0;
     /*   for (int i= 0; i< blocks.Length; i++)
        {
            GameObject obj = Instantiate(blocks[i]);
            for(int j =0; j< childblocks.Length; j++)
            {
                Instantiate(childblocks[j], obj.transform);
            }
        }*/
    }
    public static void GameOver (string WallName)
    {
        if (WallName == "BottomWall")
        {
            //gameOver;
           
        }
       
        

    }
    


    // Update is called once per frame
    void Update()
    {

       // scoreText.text = score.ToString();
    }
}
