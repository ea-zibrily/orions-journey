using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    //Animator myAnim;
    public bool isCheck;

    private void Awake()
    {
        //myAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Checkpoint");
            orionManager.LastCheckPointPos = transform.position;
            isCheck = true;
            //myAnim.SetTrigger("checkpoint");
        }
    }
}
