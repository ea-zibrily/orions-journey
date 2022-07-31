using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class boss1HPManager : MonoBehaviour
{
    public Image hpUI;
    public Image effectUI;
    public float hitSpeed;
    public TextMeshProUGUI hpText;

    public billy bill;

    private void Update()
    {
        hpUI.fillAmount = bill.hp / bill.maxHP;

        if(effectUI.fillAmount > hpUI.fillAmount)
        {
            effectUI.fillAmount -= hitSpeed;
        }
        else
        {
            effectUI.fillAmount = hpUI.fillAmount;
        }

        hpText.text = bill.hp + (" / ") + bill.maxHP;
    }

}
