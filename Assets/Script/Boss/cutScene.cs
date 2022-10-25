using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutScene : MonoBehaviour
{
    public GameObject bulletObject;
    private bullet bulletScript;

    [Header ("Checkpoint Platform")]
    public GameObject platform;
    private platformCheckpoint checkpointPlatform;

    [Header ("Spawner")]
    public GameObject spawner;
    public float waitBeforePlay;

    [Header ("Boss")]
    public GameObject billyHP;
    public GameObject billyBoss;
    private billyLaser billyLaser;
    private billy billy;
    public GameObject billyStartLaserPoint;
    private LaserStartAnim laserStart;
    private BoxCollider2D boxCollider;

    private PlayableDirector _cutScene;

    [Header ("lava")]
    public GameObject lava;

    void Awake(){
        bulletScript = bulletObject.GetComponent<bullet>();

        checkpointPlatform = platform.GetComponent<platformCheckpoint>();
        checkpointPlatform.enabled = false;

        boxCollider = billyBoss.GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        billyLaser = billyBoss.GetComponent<billyLaser>();
        billyLaser.enabled = false;
        billy = billyBoss.GetComponent<billy>();
        billy.enabled = false;
        billyHP.SetActive(false);
        laserStart = billyStartLaserPoint.GetComponent<LaserStartAnim>();
        laserStart.enabled = false;

        _cutScene = gameObject.GetComponent<PlayableDirector>();
        _cutScene.enabled = false;

        spawner.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            bulletScript.enabled = false;
            _cutScene.enabled = true;
            lava.transform.position = new Vector2(lava.transform.position.x, 20f);
            Invoke("StartCutScene", waitBeforePlay);
        }
    }

    void StartCutScene(){
        bulletScript.enabled = true;
        checkpointPlatform.enabled = true;
        spawner.SetActive(true);
        billyLaser.enabled = true;
        billy.enabled = true;
        boxCollider.enabled = true;
        laserStart.enabled = true;
        billyHP.SetActive(true);
    }
}
