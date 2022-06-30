using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header ("Move")]
    public float speed;
    public bool isRight;

    //Reference
    Rigidbody2D myRb;

    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        charaMove();
    }

    void charaMove()
    {
        float move;
        move = Input.GetAxis("Horizontal");
        myRb.velocity = new Vector2(speed * move, myRb.velocity.y);
        
        if(move > 0 && !isRight)
        {
            gameObject.transform.localScale = new Vector2(0.8f, gameObject.transform.localScale.y);
            //transform.eulerAngles = Vector2.up * 180;
            isRight = true;
        }
        if (move < 0 && isRight)
        {
            gameObject.transform.localScale = new Vector2(-0.8f, gameObject.transform.localScale.y);
            isRight = false;
        }
 
    }
}
