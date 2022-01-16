using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Transform theBall;
    static int gameScore;
   public  GameObject [] blocks;
    public GameObject[] childblocks;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
     /*   for (int i= 0; i< blocks.Length; i++)
        {
            GameObject obj = Instantiate(blocks[i]);
            for(int j =0; j< childblocks.Length; j++)
            {
                Instantiate(childblocks[j], obj.transform);
            }
        }*/
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
