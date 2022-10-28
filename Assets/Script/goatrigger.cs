using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goatrigger : MonoBehaviour
{
    Animator myAnim;
    private void Awake()
    {
        myAnim = GetComponentInParent<Animator>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myAnim.SetTrigger("close");
        }
    }
}
