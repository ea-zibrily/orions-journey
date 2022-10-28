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

    [Header("Scene List")]
    public string earthScene;
    public string marsScene;
    public string jupiterScene;

    [Header("Fader")]
    public GameObject fader;
    public FaderScene faderScene;

    void Start()
    {
        Time.timeScale = 1;
        fader.SetActive(false);
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
        fader.SetActive(true);
        faderScene.FadeSceneOut(earthScene);
    }

    public void Mars()
    {
        fader.SetActive(true);
        faderScene.FadeSceneOut(marsScene);

    }

    public void Jupiter()
    {
        fader.SetActive(true);
        faderScene.FadeSceneOut(jupiterScene);

    }


    public void Shop()
    {
        anim.SetTrigger("OpenShop");
    }

    public void Back()
    {
        anim.SetTrigger("CloseShop");
    }
}
