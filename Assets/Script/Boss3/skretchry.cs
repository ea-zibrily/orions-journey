using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class skretchry : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    Transform[] wayPoint = new Transform[4];
    Transform pointTarget;
    int randomPoint;

    [Header("Attack Area")]
    public Transform skretchRange;
    public float radiusRange;
    public LayerMask whatIsSkretch;

    [Header("Attack")]
    public float startTimeBtweenShoot;
    float btweenShoot;
    public GameObject arrow;

    [Header("Reference")]
    public GameObject deathParticle;
    GameObject bossMgrObj;
    boss3Manager bossMgr;
    shoot shootDmg;
    SpriteRenderer mySp;
    Animator myAnim;

    void Awake()
    {
        mySp = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }
    void Start()
    {
        //way
        wayPoint[0] = GameObject.Find("point1").transform;
        wayPoint[1] = GameObject.Find("point2").transform;
        wayPoint[2] = GameObject.Find("point3").transform;
        wayPoint[3] = GameObject.Find("point4").transform;

        //manager
        bossMgrObj = GameObject.Find("GrandSpace");
        bossMgr = bossMgrObj.GetComponent<boss3Manager>();

        //shoot/aim dmg
        shootDmg = GameObject.FindGameObjectWithTag("Aim").GetComponent<shoot>();

        //<summary>
        //pake random point biar arah gerak boss random
        //</summary>
        randomPoint = Random.Range(0, 3);
        switch(randomPoint)
        {
            case 0:
                pointTarget = wayPoint[0];
                break;
            case 1:
                pointTarget = wayPoint[1];
                break;
            case 2:
                pointTarget = wayPoint[2];
                break;
            case 3:
                pointTarget = wayPoint[3];
                break;
            default:
                Debug.Log("Eroro min.");
                break;
        }

        btweenShoot = startTimeBtweenShoot;
    }

    // Update is called once per frame
    void Update()
    {
        //<summary>
        //klo player ada di area tembak skretch, skretch bakal diem lur
        //begitu uga sebalikx
        //</summary>
        if (!thereAPlayer())
        {
            myAnim.SetTrigger("idle");
            skretchMove();
        }
        else
        {
            myAnim.SetTrigger("attack");
            shootPlayer();
        }

        if (bossMgr.isDeath)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    void skretchMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointTarget.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, wayPoint[0].position) <= 0.01f)
        {
            pointTarget = wayPoint[1];
            //transform.localScale = new Vector2(1.4355f, transform.localScale.y);
            mySp.flipX = false;

        }
        if(Vector2.Distance(transform.position, wayPoint[1].position) <= 0.01f)
        {
            pointTarget = wayPoint[2];
            //transform.localScale = new Vector2(-1.4355f, transform.localScale.y);
            mySp.flipX = true;
           
        }
        if (Vector2.Distance(transform.position, wayPoint[2].position) <= 0.01f)
        {
            pointTarget = wayPoint[3];
            //transform.localScale = new Vector2(-1.4355f, transform.localScale.y);
            mySp.flipX = true;

        }
        if (Vector2.Distance(transform.position, wayPoint[3].position) <= 0.01f)
        {
            pointTarget = wayPoint[0];
            //transform.localScale = new Vector2(1.4355f, transform.localScale.y);
            mySp.flipX = false;

        }
    }

    bool thereAPlayer()
    {
        return Physics2D.OverlapCircle(skretchRange.position, radiusRange, whatIsSkretch);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(skretchRange.position, radiusRange);
    }

    public void shootPlayer()
    {
        if (btweenShoot <= 0)
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
            btweenShoot = startTimeBtweenShoot;
        }
        else
        {
            btweenShoot -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            bossMgr.hp -= shootDmg.damage;
            FindObjectOfType<AudioManager>().Play("Death");
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
