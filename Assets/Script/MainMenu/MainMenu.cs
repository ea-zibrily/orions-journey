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

    void Start()
    {
        isBack = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Escape) && isBack)
        {
            anim.SetTrigger("Back");
            isBack = false;
        }
    }

    public void Earth(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void Mars(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void Jupiter(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }


    public void Shop()
    {
        anim.SetTrigger("OpenShop");
    }

    public void Back(){
        anim.SetTrigger("CloseShop");
    }

    public void LoadLevelSelect(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
