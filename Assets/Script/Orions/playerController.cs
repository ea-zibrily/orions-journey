using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class playerController : MonoBehaviour
{
    //aim
    private Transform aimTransform;

    //move
    public float moveSpeed;
    private Rigidbody2D rb;

    //ground check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //flip
    private bool facingRight;

    void Awake()
    {
        //aimTransform = transform.Find("Aim");
        rb = GetComponent<Rigidbody2D>();
    }

    //non physics
    void Update()
    {
        //check isGrounded or not
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //aim
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        
        //pindah ke script shoot
        /*Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        //weapon flip
        Vector3 aimLocalScale = Vector3.one;
        if(angle > 90 || angle < -90){
            aimLocalScale.y = -1f;
        } else {
            aimLocalScale.y = 1f;
        }
        aimTransform.localScale = aimLocalScale;*/

        if(Time.timeScale > 0){
            //call flip method
            if(mousePosition.x > transform.position.x && facingRight){
                flip();
            }else if(mousePosition.x < transform.position.x && !facingRight){
                flip();
            }
        }
    }

    //physics
    void FixedUpdate(){
        //move
        var moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput != 0 && isGrounded){
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }

    //launch Impact Player
    public void Launch(float force){
        Vector2 dir = (UtilsClass.GetMouseWorldPosition() - transform.position).normalized * -1f;
        transform.GetComponent<Rigidbody2D>().velocity = dir * force;
    }

    //flip the player
    void flip(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
