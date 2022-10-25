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
    public int damage;

    //lava ref
    private GameObject lavaObj;
    private lava lavaScript;

    void Start(){
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<playerController>();

        lavaObj = GameObject.FindGameObjectWithTag("lava");
        lavaScript = lavaObj.GetComponent<lava>();
    }

    void Update(){
        if(Time.timeScale > 0){
            //aim
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);

            //weapon flip
            Vector3 aimLocalScale = Vector3.one;
            if(angle > 90 || angle < -90){
                aimLocalScale.y = -1f;
            } else {
                aimLocalScale.y = 1f;
            }
            transform.localScale = aimLocalScale;

            if(Input.GetMouseButtonDown(0)){
                lavaScript.enabled = true;
                Shoot();
                player.Launch(playerImpact);
            }
        }
    }

    public void Shoot(){
        GameObject projectile = Instantiate(bullet, firePos.position, firePos.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePos.right * fireForce, ForceMode2D.Impulse);
        cinemaShake.Instance.shakeCamera(2.7f, 0.1f);
    }
}
