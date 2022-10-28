using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class boss3Manager : MonoBehaviour
{

    [Header("Health")]
    public float maxHp;
    public float hp;
    public float hitSpeed;
    public Image hpImage;
    public Image effectImage;
    public TextMeshProUGUI hpText;

    [Header("Reference")]
    public bool isDeath;
    public GameObject deathParticle;
    public GameObject hpPanel;
    public shoot shootDmg;
    private GameObject Aim;
    public GameObject[] spawner;

    // Start is called before the first frame update
    void Start()
    {
        Aim = GameObject.FindGameObjectWithTag("Aim");
        shootDmg = Aim.GetComponent<shoot>();

        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
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

        hpText.text = hp + ("/") + maxHp;

        //death condition
        if (hp < 1)
        {
            isDeath = true;
            hpPanel.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                spawner[i].gameObject.SetActive(false);
            }
        }
    }

}
