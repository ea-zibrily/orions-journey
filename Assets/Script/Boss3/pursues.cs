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

    [Header("Reference")]
    Rigidbody2D myRb;
    public GameObject deathParticle;
    public shoot damage;
    public boss3Manager bossHp;

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

        if(bossHp.isDeath)
        {
            Destroy(gameObject);
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
        switch(collision.gameObject.tag)
        {
            case "Player":
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
            case "Bullet":
                bossHp.hp -= damage.damageTaken;
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
        }
    }
}
