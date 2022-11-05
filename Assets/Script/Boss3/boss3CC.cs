using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class boss3CC : MonoBehaviour
{
    public PlayableDirector[] boss3;
    public GameObject[] boss3Obj;
    public GameObject[] spawner;
    public GameObject hpPanel;
    public Animator boss3Anim;
    public float animTime;
    public bool csDone;

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            boss3[i].enabled = false;
        }
    }

    private void Update()
    {
        if(csDone)
        {
            hpPanel.SetActive(true);

            spawner[0].SetActive(true);
            spawner[1].SetActive(true);
            spawner[2].SetActive(true);
            spawner[3].SetActive(true);
            spawner[4].SetActive(true);
            spawner[5].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            for(int i = 0; i < 6; i++)
            {
                boss3Obj[i].SetActive(true);
            }

            boss3Anim.SetTrigger("gressor");
            boss3[0].enabled = true;
            boss3[3].enabled = true;
            Invoke(("skretchCam"), animTime);

            //StartCoroutine(bossAnimCoroutine());
        }
    }

    void skretchCam()
    {
        boss3Anim.SetTrigger("skretchry");
        boss3[1].enabled = true;
        boss3[4].enabled = true;
        Invoke(("pursCam"), animTime);
    }

    void pursCam()
    {
        boss3Anim.SetTrigger("pursues");
        boss3[2].enabled = true;
        boss3[5].enabled = true;
        Invoke(("arenaCam"), animTime);
    }

    void arenaCam()
    {
        csDone = true;
        boss3Anim.SetTrigger("arena");
    }


    /*
    //<summary>
    //bisa pake invoke sama ienumerator si
    //tapi aku nyoba pake invoke ae dek
    //</summary>
    
    IEnumerator bossAnimCoroutine()
    {
        boss3Anim.SetTrigger(gress);
        boss3[0].enabled = true;

        yield return new WaitForSeconds(animTime);
        boss3Anim.SetTrigger(skretch);
        boss3[1].enabled = true;

        yield return new WaitForSeconds(animTime);
        boss3Anim.SetTrigger(purs);
        boss3[2].enabled = true;

        yield return new WaitForSeconds(animTime);
        boss3Anim.SetTrigger(arena);
        hpPanel.SetActive(true);
    }
    */

}
