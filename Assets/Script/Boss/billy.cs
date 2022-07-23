using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class billy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    public GameObject billyHP;
    public int health;
    public Slider healthBar;

    [Header("Death")]
    public Transform endPositionBillyDeath;
    private billyLaser billyLaser;
    private LineRenderer laser;
    private float destroyBilly = 2f;
    public GameObject deathVfx;
    public GameObject spawnerPlatform;

    public GameObject platform;
    private platformBilly platformBilly;


    void Start(){
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        healthBar.maxValue = health;
        
        billyLaser = GetComponent<billyLaser>();
        laser = GetComponent<LineRenderer>();
    }

    void Update(){
        healthBar.value = health;
        if(health <= 0){
            laser.enabled = false;
            billyLaser.enabled = false;
            Invoke("Death", 2f);
        }

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
            if(waitTime <= 0){
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void TakingDamage(){
        health--;
    }

    void Death(){
        transform.position = Vector3.Lerp(transform.position, endPositionBillyDeath.position, Time.deltaTime);
        destroyBilly -= Time.deltaTime;
        if(destroyBilly <= 0){
            Destroy(spawnerPlatform);
            Instantiate(deathVfx, transform.position, Quaternion.identity);
            billyHP.SetActive(false);
            Destroy(gameObject);
        }
    }
}
