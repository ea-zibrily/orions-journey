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

    public void Earth()
    {
        Debug.Log("Earth Pressed");
    }

    public void Mars()
    {
        Debug.Log("Mars Pressed");

    }

    public void Jupiter()
    {

        Debug.Log("Jupiter Pressed");
    }

    public void Shop()
    {
        Debug.Log("Shop Pressed");

    }
}
