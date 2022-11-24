using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    //Animator myAnim;
    public bool isCheck;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Checkpoint");
            boxCollider2D.enabled = false;
            orionManager.LastCheckPointPos = transform.position;
            isCheck = true;
            //myAnim.SetTrigger("checkpoint");
        }
    }
}
