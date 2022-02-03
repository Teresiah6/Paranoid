using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelSelect : MonoBehaviour
{
    public GameObject AboutDeveloper;

     
    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPressed(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
    public void AboutDev()
    {
        AboutDeveloper.SetActive(true);
    }
    public void ExitAboutDev()
    {
        AboutDeveloper.SetActive(false);
    }
}
