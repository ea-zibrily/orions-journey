using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class orionManager : MonoBehaviour
{
    [Header("Weapon Selection")]
    public GameObject[] weaponPrefabs;
    int weaponIndex;

    [Header ("Coin")]
    [SerializeField] public int coin;
    //gae text mesh ben ga pecah
    [SerializeField] public TextMeshProUGUI coinUI;

    [Header ("Checkpoint")]
    [SerializeField] public string check = "sudah cekpoing lur";
    // [SerializeField] public static Vector2 LastCheckPointPos = new Vector2(0, -2.507308f);
    [SerializeField] public static Vector2 LastCheckPointPos;

    [Header("Health")]
    [SerializeField] public GameObject[] health;
    [SerializeField] public int healthIndex;
    [SerializeField] public GameObject deathVfx;

    void Awake()
    {
        weaponIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);
        Instantiate(weaponPrefabs[weaponIndex], transform);

        coin = PlayerPrefs.GetInt("totalCoin", 0);
        // GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPointPos;
        Debug.Log(check);
    }

    void Update()
    {
        coinUI.text = coin.ToString();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("coin"))
        {
            getCoin();
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("enemy"))
        {
            orionHealth();
        }

        if (collision.CompareTag("Boss"))
        {
            orionHealth();
        }

        if (collision.CompareTag("Boss3"))
        {
            orionHealth();
        }
    }

    void getCoin()
    {
        coin++;
        PlayerPrefs.SetInt("totalCoin", coin);
    }

    public void orionHealth()
    {
        healthIndex--;
        if(healthIndex < 1)
        {
            healthIndex = 0;
            Destroy(gameObject);
        }
        health[healthIndex].SetActive(false);
    }

    void OnDestroy(){
        Instantiate(deathVfx, transform.position, Quaternion.identity);
    }

    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
