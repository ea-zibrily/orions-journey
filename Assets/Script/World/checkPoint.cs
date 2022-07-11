using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            orionManager.LastCheckPointPos = transform.position;
            myAnim.SetTrigger("checkpoint");
        }
    }
}
