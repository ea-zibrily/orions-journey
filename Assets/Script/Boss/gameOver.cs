using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public GameObject boss;
    public GameObject gameOverWinUI;

    void Update(){
        if(boss == null){
            Invoke("GameOver", 1.5f);
        }
    }

    void GameOver(){
        Time.timeScale = 0;
        gameOverWinUI.SetActive(true);
    }

    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverWinUI.SetActive(false);
        orionManager.LastCheckPointPos = new Vector2(0, -10.8f);
    }
}
