using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skretchry : MonoBehaviour
{
    [Header("Movement")]
    public Transform wayPoint1;
    public Transform wayPoint2;
    Transform pointTarget;
    public float speed;
    //int randomPoint; //blom kepake

    [Header("Attack Area")]
    public Transform skretchRange;
    public float radiusRange;
    public LayerMask whatIsSkretch;

    [Header("Attack")]
    public float startTimeBtweenShoot;
    float btweenShoot;
    public GameObject arrow;

    //ref
    SpriteRenderer mySp;

    void Awake()
    {
        mySp = GetComponent<SpriteRenderer>();
        Debug.Log("Lesgoo");
    }
    void Start()
    {
        /*
        masi belum kepake dek
        randomPoint = Random.Range(1, 4);
        switch(randomPoint)
        {
            case 1:
                pointTarget = wayPoint1;
                break;
            case 2:
                pointTarget = wayPoint2;
                break;
            case 3:
                pointTarget = wayPoint3;
                break;
            case 4:
                pointTarget = wayPoint4;
                break;
            default:
                Debug.Log("Eroro min");
                break;
        }
        */

        pointTarget = wayPoint1;
        btweenShoot = startTimeBtweenShoot;
    }

    // Update is called once per frame
    void Update()
    {
        //note
        //klo player ada di area tembak skretch, skretch bakal diem lur
        //begitu uga sebalikx
        if(!thereAPlayer())
        {
            skretchMove();
        }
        else
        {
            shootPlayer();
        }

    }

    void skretchMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointTarget.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, wayPoint1.position) <= 0.01f)
        {
            pointTarget = wayPoint2;
            transform.localScale = new Vector2(1.8125f, transform.localScale.y);

            /*
            //karena gameobject terpisah jadi gabisa pake flip
            mySp.flipX = true;
            */
        }
        if(Vector2.Distance(transform.position, wayPoint2.position) <= 0.01f)
        {
            pointTarget = wayPoint1;
            transform.localScale = new Vector2(-1.8125f, transform.localScale.y);

            /*
            //karena gameobject terpisah jadi gabisa pake flip
            //mySp.flipX = false;
            */
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

    void shootPlayer()
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
}
