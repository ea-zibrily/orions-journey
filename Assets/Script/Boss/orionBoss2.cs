using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orionBoss2 : MonoBehaviour
{
    [Header("Boss Idle")]
    [SerializeField] public float idleSpeed;
    [SerializeField] public Vector2 idleDirection;

    [Header("Boss Attack Up n Down")]
    [SerializeField] public float attackSpeed;
    [SerializeField] public Vector2 attackDirection;

    [Header("BossIdle")]
    [SerializeField] public float attackPlayerSpeed;
    [SerializeField] public Transform player;
    private Vector2 playerPosition;
    private bool hasPlayerPosition;

    [Header("Checker")]
    [SerializeField] public float checkRadius;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public Transform wallCheck;
    [SerializeField] public Transform topCheck;
    [SerializeField] public LayerMask whatIsGround;

    [Header("Local Scale")]
    [SerializeField] public float leftX;
    [SerializeField] public float rightX;

    //etc
    public bool isLeft;
    private bool goingUp = true;
    private string Attack = "AttackUpDown";
    private string AttackPlayer = "AttackPlayer";
    private string Slammed = "Slammed";

    //Reference
    Rigidbody2D enemyRb;
    Animator enemyAnim;


    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    void Start()
    {
        idleDirection.Normalize();
        attackDirection.Normalize();
    }

    public void randomBossState()
    {
        float randomPick = Random.Range(0, 2);

        //randomisasi
        switch (randomPick)
        {
            case 0:
                enemyAnim.SetTrigger(Attack);
                break;
            case 1:
                enemyAnim.SetTrigger(AttackPlayer);
                break;
            default:
                Debug.Log("Udah bre");
                break;
        }
    }

    public void bossIdle()
    {
        enemyRb.velocity = idleDirection * idleSpeed;

        //ganti arah
        if (isTop() && goingUp)
        {
            changeDirection();
        }
        else if (isGround() && !goingUp)
        {
            changeDirection();
        }

        //flip boss
        if (isWall() && isLeft)
        {
            flip();
            transform.localScale = new Vector2(rightX, transform.localScale.y);
        }
        else if (isWall() && !isLeft)
        {
            flip();
            transform.localScale = new Vector2(leftX, transform.localScale.y);
        }
    }

    public void bossAttackUpDown()
    {
        enemyRb.velocity = attackDirection * attackSpeed;

        //ganti arah
        if (isTop() && goingUp)
        {
            changeDirection();
        }
        else if (isGround() && !goingUp)
        {
            changeDirection();
        }

        //flip boss
        if (isWall() && isLeft)
        {
            flip();
            transform.localScale = new Vector2(rightX, transform.localScale.y);
        }
        else if (isWall() && !isLeft)
        {
            flip();
            transform.localScale = new Vector2(leftX, transform.localScale.y);
        }
    }

    public void bossAttackPlayer()
    {
        //dash ke player
        if(!hasPlayerPosition)
        {
            //take player position
            playerPosition = player.position - transform.position;

            //normalize player position;
            playerPosition.Normalize();
            hasPlayerPosition = true;
        }
        else
        {
            //kejar player
            enemyRb.velocity = playerPosition * attackPlayerSpeed;
        }

        //animasi slebew slemek
        if(isGround() || isWall())
        {
            hasPlayerPosition = false;
            //animasion
            enemyRb.velocity = Vector2.zero;
            enemyAnim.SetTrigger(Slammed);
        }

       
    }

    void changeDirection()
    {
        goingUp = !goingUp;
        idleDirection.y *= -1;
        attackDirection.y *= -1;
    }

    void flip()
    {
        isLeft = !isLeft;
        idleDirection.x *= -1;
        attackDirection.x *= -1;
    }

    void flipTowardPlayer()
    {
        float move = player.position.x - transform.position.x;

        //puter
        if(move > 0 && isLeft)
        {
            flip();
            transform.localScale = new Vector2(rightX, transform.localScale.y);
        }
        else if(move < 0 && !isLeft)
        {
            flip();
            transform.localScale = new Vector2(leftX, transform.localScale.y);
        }
    }

    bool isGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    bool isWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, checkRadius, whatIsGround);
    }
    bool isTop()
    {
        return Physics2D.OverlapCircle(topCheck.position, checkRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        Gizmos.DrawWireSphere(wallCheck.position, checkRadius);
        Gizmos.DrawWireSphere(topCheck.position, checkRadius);
    }
}
