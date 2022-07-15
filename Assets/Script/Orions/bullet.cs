using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag){
            case "Platform" :
                Destroy(gameObject);
                break;
            //add enemy or others
        }
        //hit box
        if (other.CompareTag("box"))
        {
            Destroy(other.gameObject);
            //other.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

}
