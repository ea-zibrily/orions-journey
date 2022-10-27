using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPause;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isPause)
        {
            Time.timeScale = 0;
            isPause = true;
            pausePanel.SetActive(true);
            Debug.Log("Game Pause!");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isPause)
        {
            Time.timeScale = 1;
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
        Time.timeScale = 1;
        isPause = false;
        pausePanel.SetActive(false);
        Debug.Log("Game Resume!");
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void selectLevel(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

}
