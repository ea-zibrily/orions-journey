using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cameraControll : MonoBehaviour
{
    public Animator myAnim;
    public PlayableDirector director;
    public GameObject hpPanel;

    private void Awake()
    {
        director.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            myAnim.SetTrigger("bossCam");
            director.enabled = true;
            Invoke("arenaCam", 3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myAnim.SetTrigger("playerCam");
        }
    }

    void arenaCam()
    {
        myAnim.SetTrigger("bossArenaCam");
        hpPanel.SetActive(true);
    }
}
