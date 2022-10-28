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
    public GameObject bossLaser;
    private billyLaser billyLaser;
    private billy billy;
    private BoxCollider2D boxCollider;

    [Header("Lava")]
    public GameObject lava;
    private lava lavaScript;

    private PlayableDirector _cutScene;

    void Awake(){
        bulletScript = bulletObject.GetComponent<bullet>();

        checkpointPlatform = platform.GetComponent<platformCheckpoint>();
        checkpointPlatform.enabled = false;

        boxCollider = bossLaser.GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        billyLaser = bossLaser.GetComponent<billyLaser>();
        billyLaser.enabled = false;
        billy = billyBoss.GetComponent<billy>();
        billy.enabled = false;
        billyHP.SetActive(false);

        _cutScene = gameObject.GetComponent<PlayableDirector>();
        _cutScene.enabled = false;

        lavaScript = lava.GetComponent<lava>();

        spawner.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            lavaScript.CutScene();
            bulletScript.enabled = false;
            _cutScene.enabled = true;
            Invoke("StartCutScene", waitBeforePlay);
        }
    }

    void StartCutScene(){
        bulletScript.enabled = true;
        checkpointPlatform.enabled = true;
        spawner.SetActive(true);
        boxCollider.enabled = true;
        billyLaser.enabled = true;
        billy.enabled = true;
        billyHP.SetActive(true);
    }
}
