using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator anim;
    private bool isBack;
    private bool isStart;
    private bool isInfoDisplay;
    public GameObject planetInfo;

    [Header("Fader")]
    public GameObject faderObj;
    public FaderScene faderSceneScript;
    public string earthLevelName;
    public string marsLevelName;
    public string jupiterLevelName;

    [Header("LevelUnlock")]
    public Button[] levelButton;
    private int levelIndex;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
        FindObjectOfType<AudioManager>().Stop("InGameTheme");
        
        levelIndex = PlayerPrefs.GetInt("LevelUnlocked", 1);
        for (int i = 0; i < levelButton.Length; i++)
        {
            levelButton[i].interactable = false;
        }
        
        for (int i = 0; i < levelIndex; i++)
        {
            levelButton[i].interactable = true;
        }

        Time.timeScale = 1;
        isBack = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (planetInfo.activeSelf)
        {
            isInfoDisplay = true;
        }
        else
        {
            isInfoDisplay = false;
        }

        if (Input.anyKeyDown && !isBack)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

            }
            else
            {
                FindObjectOfType<AudioManager>().Play("GameStart");
                faderObj.SetActive(false);
                anim.SetTrigger("StartGame");
                isBack = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && isBack && !isInfoDisplay)
        {
            anim.SetTrigger("Back");
            isBack = false;
        }
    }

    public void Earth()
    {
        faderObj.SetActive(true);
        faderSceneScript.SceneLoad(earthLevelName);
    }

    public void Mars()
    {
        faderObj.SetActive(true);
        faderSceneScript.SceneLoad(marsLevelName);
    }

    public void Jupiter()
    {
        faderObj.SetActive(true);
        faderSceneScript.SceneLoad(jupiterLevelName);
    }


    public void Shop()
    {
        anim.SetTrigger("OpenShop");
    }

    public void Back()
    {
        anim.SetTrigger("CloseShop");
    }

    // public void LoadLevelSelect(string sceneName)
    // {
    //     SceneManager.LoadScene(sceneName);
    // }
}
