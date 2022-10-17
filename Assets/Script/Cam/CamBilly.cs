using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBilly : MonoBehaviour
{
    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            anim.SetBool("Switch", true);
        }
    }

    // void OnTriggerExit2D(Collider2D other){
    //     if(other.gameObject.tag == "Player"){
    //         anim.SetBool("Switch", false);
    //     }
    // }
}
