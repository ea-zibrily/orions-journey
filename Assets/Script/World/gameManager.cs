using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameManager : MonoBehaviour
{
    [Header("Fader")]
    public GameObject faderObj;
    public FaderScene faderSceneScript;
    public string thisLevelName;
    public string mainMenuName;

    [Header("Pause")]
    public GameObject pausePanel;
    public bool isPause;

    [Header("Game Over")]
    public GameObject boss;
    public GameObject gameOverWinUI;
    private bool isGameOver;

    private void Awake()
    {
        /*
        Time.timeScale = 1;
        isGameOver = false;
        pausePanel.SetActive(false);
        gameOverWinUI.SetActive(false);
        */
    }

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("InGameTheme");
        FindObjectOfType<AudioManager>().Stop("MainMenuTheme");

        Time.timeScale = 1;
        isGameOver = false;
        pausePanel.SetActive(false);
        gameOverWinUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //delete?
        if(Input.GetKeyDown(KeyCode.L)){
            PlayerPrefs.DeleteAll();
        }

        if (boss == null)
        {
            isGameOver = true;
            FindObjectOfType<AudioManager>().Stop("InGameTheme");
            Invoke("GameOver", 1f);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !isPause && !isGameOver)
        {
            FindObjectOfType<AudioManager>().Pause("InGameTheme");
            Time.timeScale = 0;
            faderObj.SetActive(false);
            isPause = true;
            pausePanel.SetActive(true);
            Debug.Log("Game Pause!");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause && !isGameOver)
        {
            FindObjectOfType<AudioManager>().Play("InGameTheme");
            Time.timeScale = 1;
            faderObj.SetActive(true);
            isPause = false;
            pausePanel.SetActive(false);
            Debug.Log("Game Resume!");
        }
    }

    //<summary>
    //method/func buat pause panel
    //</summary>

    public void resume()
    {
        FindObjectOfType<AudioManager>().Play("InGameTheme");
        Time.timeScale = 1;
        faderObj.SetActive(true);
        isPause = false;
        pausePanel.SetActive(false);
        Debug.Log("Game Resume!");
    }
    public void restart()
    {
        FindObjectOfType<AudioManager>().Pause("InGameTheme");
        faderObj.SetActive(true);
        Time.timeScale = 1;
        orionManager.LastCheckPointPos = new Vector2(0, 0);
        faderSceneScript.SceneLoad(thisLevelName);
    }

    public void MainMenuFromGameOver(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if(currentLevel >= PlayerPrefs.GetInt("LevelUnlocked")){
            PlayerPrefs.SetInt("LevelUnlocked", currentLevel + 1);
        }
        orionManager.LastCheckPointPos = new Vector2(0, 0);
        faderObj.SetActive(true);
        Time.timeScale = 1;
        faderSceneScript.SceneLoad(mainMenuName);
    }

    public void selectLevel()
    {
        orionManager.LastCheckPointPos = new Vector2(0, 0);
        faderObj.SetActive(true);
        Time.timeScale = 1;
        faderSceneScript.SceneLoad(mainMenuName);
    }

    public void exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    //<summary>
    //method/func buat game over panel
    //</summary>

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverWinUI.SetActive(true);
    }

}
