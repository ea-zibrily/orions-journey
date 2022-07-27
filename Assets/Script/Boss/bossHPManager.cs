using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bossHPManager : MonoBehaviour
{
    [Header("Health Bar")]
    [SerializeField] public Image hpImage;
    [SerializeField] public Image hpEffect;
    [SerializeField] private float hitSpeed = 0.005f;
    [SerializeField] public TextMeshProUGUI healthUI;

    //Ref
    public bossManager bossManager;
    private void Awake()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = bossManager.hp / bossManager.maxHp;

        if(hpEffect.fillAmount > hpImage.fillAmount)
        {
            hpEffect.fillAmount -= hitSpeed;
        }
        else
        {
            hpEffect.fillAmount = hpImage.fillAmount;
        }

        if (bossManager.bossDeath)
        {
            gameObject.SetActive(false);
        }

        healthUI.text = bossManager.hp + (" / ") + bossManager.maxHp;
    }
}
