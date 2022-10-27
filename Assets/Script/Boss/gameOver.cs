using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    [Header("Scene List")]
    public string mainMenuSceneName;
    public string thisLevelName;

    [Header("Fader")]
    public FaderScene faderScene;

    [Header("Ref")]
    public GameObject boss;
    public GameObject gameOverWinUI;
    public GameObject lava;
    BoxCollider2D boxCollider2D;

    void Start(){
        gameOverWinUI.SetActive(false);
        boxCollider2D = lava.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (boss == null)
        {
            boxCollider2D.enabled = false;
            Invoke("GameOver", 1f);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverWinUI.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        faderScene.FadeSceneOut(thisLevelName);
        orionManager.LastCheckPointPos = new Vector2(0, 0);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        faderScene.FadeSceneOut(mainMenuSceneName);
        orionManager.LastCheckPointPos = new Vector2(0, 0);
    }
}
