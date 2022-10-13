using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursues : MonoBehaviour
{
    [Header("Movement")]
    public float purSpeed;
    public Transform player;
    bool hasPlayerPos;
    Vector2 playerPos;

    [Header("Area")]
    public Transform pursuesArea;
    public float radius;
    public LayerMask whatisPursues;

    //ref
    Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Debug.Log("Lesgo Pursues!");
        //hasPlayerPos = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnArea())
        {
            purAttack();
        }
    }

    void purAttack()
    {
        //<summary
        //buat pursues ada 2 cara,
        //1 bikin dia lock posisi player
        //2 kejar player sampe dapet
        //</summary>

        //lock posisi player
        /*
        if(!hasPlayerPos)
        {
            //take position
            playerPos = player.position - transform.position;

            //normalize posisi player
            playerPos.Normalize();
            hasPlayerPos = true;
        }
        else
        {
            myRb.velocity = playerPos * purSpeed;
        }
        */

        //kejar player
        transform.position = Vector2.MoveTowards(transform.position, player.position, purSpeed * Time.deltaTime);

    }

    bool isOnArea()
    {
        return Physics2D.OverlapCircle(pursuesArea.position, radius, whatisPursues);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pursuesArea.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
