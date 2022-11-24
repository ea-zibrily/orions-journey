using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gressor : MonoBehaviour
{
    [Header("Movement")]
    public float gresSpeed;
    Transform player;

    [Header("Attack Area")]
    public Transform gress;
    public float radiusGress;
    public LayerMask whatisGress;

    [Header("Reference")]
    Animator myAnim;
    public GameObject deathParticle;
    GameObject bossMgrObj;
    boss3Manager bossMgr;
    shoot shootDmg;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        //<summary>
        //manager refs ada di start menyesuaikan isi variabel di scrip boss3Manager
        //</summary>

        bossMgrObj = GameObject.Find("GrandSpace");
        bossMgr = bossMgrObj.GetComponent<boss3Manager>();

        shootDmg = GameObject.FindGameObjectWithTag("Aim").GetComponent<shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, gresSpeed * Time.deltaTime);

        if (therePlayerArea())
        {
            myAnim.SetTrigger("attack");
        }
        else
        {
            myAnim.SetTrigger("idle");
        }

        if (bossMgr.isDeath)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
    bool therePlayerArea()
    {
        return Physics2D.OverlapCircle(gress.position, radiusGress, whatisGress);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gress.position, radiusGress);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            bossMgr.hp -= shootDmg.damage;
            FindObjectOfType<AudioManager>().Play("Death");
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
