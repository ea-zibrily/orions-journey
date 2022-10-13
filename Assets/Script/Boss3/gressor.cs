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

    public Transform playerArea;
    public float radiusPlayer;
    public LayerMask whatisGress;

    //ref
    Animator myAnim;
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
        if(therePlayerPos())
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, gresSpeed * Time.deltaTime);
        }

        attack();
    }

    bool therePlayerPos()
    {
        return Physics2D.OverlapCircle(gress.position, radiusGress, whatisGress);
    }

    bool thereAPlayer()
    {
        return Physics2D.OverlapCircle(playerArea.position, radiusPlayer, whatisGress);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gress.position, radiusGress);
        Gizmos.DrawWireSphere(playerArea.position, radiusPlayer);
    }

    void attack()
    {
        if(thereAPlayer())
        {
            //myAnim.SetTrigger("attack");
        }
    }
}
