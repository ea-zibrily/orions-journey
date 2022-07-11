using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class orionCoin : MonoBehaviour
{
    public float coin;
    //gae text mesh ben ga pecah
    public TextMeshProUGUI coinUI;

    void getCoin()
    {
        coin++;
        coinUI.text = coin.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("coin"))
        {
            getCoin();
            Destroy(collision.gameObject);
        }
    }
}
