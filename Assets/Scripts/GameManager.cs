using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Transform theBall;
    static int gameScore;
    //public int blocks;
    public bool isGameStarted;
    public GameObject gameStartPanel;
    public static bool levelCompleted;
    public GameObject levelCompletedPanel;
    public GameObject gameOverPanel;

    
   // public static int numberOfBlocksHit;
  //  public static int score = 0; 
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
      //  blocks = GameObject.FindGameObjectsWithTag("Block").Length;
       
        gameStartPanel.SetActive(true);
        Time.timeScale = 0;
        
        levelCompletedPanel.SetActive(false);
        gameOverPanel.SetActive(false);
       
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
        //if(gameObject.CompareTag("block") == 0){ }
      /* if(blocks<=0)
        {
            
            levelCompletedPanel.SetActive(true);
            //SceneManager.LoadScene("Level");
            Time.timeScale = 0;
         
        }*/

       // scoreText.text = score.ToString();
    }
    public void StartGame()

    {
        gameStartPanel.SetActive(false);
        isGameStarted = true;
        Time.timeScale = 1;

    }

    public void TryAgain(string scene)
    {
        SceneManager.LoadScene(scene);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
      
    }
    public void NextLevel(string scene)
    {
        Time.timeScale = 1;
        levelCompletedPanel.SetActive(false);
        SceneManager.LoadScene(scene);
        
        
    }
    public void MainMenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
