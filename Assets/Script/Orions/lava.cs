using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    private GameObject player;

    public float endPosition;
    public float moveSpeed;

    void Awake(){
        player = GameObject.Find("Player");
    }

    void FixedUpdate(){
        transform.position = Vector2.MoveTowards(transform.position, 
            new Vector2(transform.position.x, endPosition), 
            moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == ("Player")){
            player.SetActive(false);
            this.enabled = false;
        }
    }
}
