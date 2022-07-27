using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossManager : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] public float hp;
    [SerializeField] public float maxHp;
    [SerializeField] public float damagetaken;

    //etc
    public bool bossDeath;

    //Ref
    bossHPManager bossHP;
    public goa goaOpen;
    public GameObject deathParticle;

    private void Awake()
    {
        hp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            hp -= 25;
            if (hp < 1)
            {
                bossDeath = true;
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                goaOpen.openGoa();
            }
        }
    }
    
}
