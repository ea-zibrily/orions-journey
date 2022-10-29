using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public static Vector2 testBos = new Vector2(0.78f, 225.32f);

    [Header("Health")]
    [SerializeField] public GameObject[] health;
    [SerializeField] public int healthIndex;
    [SerializeField] public GameObject deathVfx;

    [Header("Iframes")]
    public Color flashColor;
    public Color regColor;
    public float flashDuration;
    public int numberofFlash;

    [Header("Reference")]
    public lava lava;
    SpriteRenderer mySprite;

    [Header("Fader")]
    public FaderScene faderSceneScript;
    public string thisLevelName;

    void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();

        weaponIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);
        Instantiate(weaponPrefabs[weaponIndex], transform);

        coin = PlayerPrefs.GetInt("totalCoin", 0);
        //GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPointPos;
        GameObject.FindGameObjectWithTag("Player").transform.position = testBos;
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
            FindObjectOfType<AudioManager>().Play("Coin");
            getCoin();
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("enemy"))
        {
            // orionHealth();
            StartCoroutine(iframesCo());
        }

        if (collision.CompareTag("Boss"))
        {
            // orionHealth();
            StartCoroutine(iframesCo());
        }

        if (collision.CompareTag("Boss2"))
        {
            // orionHealth();
            StartCoroutine(iframesCo());
        }

        if (collision.CompareTag("Boss3"))
        {
            // orionHealth();
            StartCoroutine(iframesCo());
        }
        
        if (collision.CompareTag("lava"))
        {
            lava.enabled = false;            

            for (int i = healthIndex; i > 0; i--)
            {
                healthIndex--;
                health[healthIndex].SetActive(false);
            }
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<AudioManager>().Pause("InGameTheme");
            Instantiate(deathVfx, transform.position, Quaternion.identity);
            faderSceneScript.SceneLoad(thisLevelName);
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }

    void getCoin()
    {
        coin++;
        PlayerPrefs.SetInt("totalCoin", coin);
    }

    // void orionHealth()
    // {
    //     healthIndex--;
    //     if(healthIndex < 1)
    //     {
    //         healthIndex = 0;
    //         Destroy(gameObject);
    //     }
    //     health[healthIndex].SetActive(false);
    // }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator iframesCo()
    {
        FindObjectOfType<AudioManager>().Play("GotHit");
        healthIndex--;
        health[healthIndex].SetActive(false);

        int temp = 0;
        //myCol.enabled = false;
        Physics2D.IgnoreLayerCollision(7, 8, true);
        
        while (temp < numberofFlash)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        //myCol.enabled = true;
        Physics2D.IgnoreLayerCollision(7, 8, false);
        
        if(healthIndex < 1)
        {
            healthIndex = 0;
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<AudioManager>().Pause("InGameTheme");
            Instantiate(deathVfx, transform.position, Quaternion.identity);
            faderSceneScript.SceneLoad(thisLevelName);
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
        
    }

}
