using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cameraControll : MonoBehaviour
{
    public Animator camAnim;
    public Animator goaAnim;
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
            camAnim.SetTrigger("bossCam");
            director.enabled = true;
            goaAnim.SetTrigger("close");
            Invoke("arenaCam", 3f);
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camAnim.SetTrigger("playerCam");
        }
    }
    */

    void arenaCam()
    {
        camAnim.SetTrigger("bossArenaCam");
        hpPanel.SetActive(true);
    }
}
