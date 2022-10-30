using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursues : MonoBehaviour
{
    [Header("Movement")]
    public float purSpeed;
    Transform player;
    bool hasPlayerPos;
    Vector2 playerPos;

    [Header("Area")]
    public Transform pursuesArea;
    public float radius;
    public LayerMask whatisPursues;

    [Header("Reference")]
    Rigidbody2D myRb;
    Animator myAnim;
    public GameObject deathParticle;
    GameObject bossMgrObj;
    boss3Manager bossMgr;
    shoot shootDmg;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //hasPlayerPos = false;

        //manager
        bossMgrObj = GameObject.Find("GrandSpace");
        bossMgr = bossMgrObj.GetComponent<boss3Manager>();

        //shoot/aim dmg
        shootDmg = GameObject.FindGameObjectWithTag("Aim").GetComponent<shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnArea())
        {
            myAnim.SetTrigger("attack");
            purAttack();
        }
        else
        {
            myAnim.SetTrigger("idle");
        }
            
        
        if(bossMgr.isDeath)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
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
                FindObjectOfType<AudioManager>().Play("Death");
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
            case "Bullet":
                FindObjectOfType<AudioManager>().Play("Death");
                bossMgr.hp -= shootDmg.damage;
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
        }
    }
}
