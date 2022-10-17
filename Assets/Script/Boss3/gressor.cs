using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gressor : MonoBehaviour
{
    [Header("Movement")]
    public float gresSpeed;
    Transform player;
    public bool earlyMove;

    [Header("Attack Area")]
    public Transform gress;
    public float radiusGress;
    public LayerMask whatisGress;

    [Header("Reference")]
    Animator myAnim;
    public GameObject deathParticle;
    public shoot damage;
    public boss3Manager bossHp;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
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

        if (bossHp.isDeath)
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
            bossHp.hp -= damage.damageTaken;
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
