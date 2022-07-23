using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCheckpoint : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.down * 100f, moveSpeed * Time.fixedDeltaTime); 
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Destroyer"){
            Destroy(gameObject);
        }
        if(other.CompareTag("Player")){
            other.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.gameObject.transform.SetParent(null);
        }
    }
}
