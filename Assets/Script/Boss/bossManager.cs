using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bossManager : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] public float hp;
    [SerializeField] public float maxHp;
    [SerializeField] public float hitSpeed;
    [SerializeField] public Image hpImage;
    [SerializeField] public Image effectImage;
    [SerializeField] public TextMeshProUGUI hpText;
    [SerializeField] public GameObject hpbarPanel;


    //etc
    public bool bossDeath;

    //Ref
    public shoot shootDamage;
    public goa goaOpen;
    public GameObject deathParticle;

    private void Awake()
    {
        hp = maxHp;
        hpbarPanel.SetActive(false);
    }

    private void Update()
    {
        hpImage.fillAmount = hp / maxHp;

        if (effectImage.fillAmount > hpImage.fillAmount)
        {
            effectImage.fillAmount -= hitSpeed;
        }
        else
        {
            effectImage.fillAmount = hpImage.fillAmount;
        }

        hpText.text = hp + (" / ") + maxHp;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            hp -= shootDamage.damageTaken;
            if (hp < 1)
            {
                bossDeath = true;
                hpbarPanel.SetActive(false);
                Instantiate(deathParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                goaOpen.openGoa();
            }
        }
    }
    
}
