using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class shoot : MonoBehaviour
{
    //player refs
    private playerController player;
    private GameObject playerObj;
    public float playerImpact;

    //shoot
    public GameObject bullet;
    public Transform firePos;
    public float fireForce;

    void Awake(){
        playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<playerController>();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Shoot();
            player.Launch(playerImpact);
        }
    }

    public void Shoot(){
        GameObject projectile = Instantiate(bullet, firePos.position, firePos.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePos.right * fireForce, ForceMode2D.Impulse);
    } 
}
