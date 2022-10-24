using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billyLaser : MonoBehaviour
{

    public Transform laserFirePoint;
    public Transform laserFirePointEnd;
    private LineRenderer lr;
    private bool isShooting;

    public LayerMask layer;
    public float lineLength;
    
    public Texture[] textures;
    private int animationStep;
    public float fps;
    private float fpsCounter;

    [Header("Orion")]
    public orionManager OrionScript;
    
    void Start(){
        isShooting = false;
        lr = GetComponent<LineRenderer>();
    }

    void Update(){
        StartCoroutine(Shoot());
        
        fpsCounter += Time.deltaTime;
        if(fpsCounter >= 1f / fps){
            animationStep++;
            if(animationStep == textures.Length){
                animationStep = 0;
            }

            lr.material.SetTexture("_MainTex", textures[animationStep]);

            fpsCounter = 0f;
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos){
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }    

    IEnumerator Shoot(){
        if(isShooting == true){
            lr.enabled = true;

            RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, laserFirePoint.right, lineLength, layer);
            
            if(hit){
                
                //Take Damage
                // OrionScript.orionHealth();

                Draw2DRay(laserFirePoint.position, hit.point);
            } else {
                Draw2DRay(laserFirePoint.position, laserFirePointEnd.position);
            }

            yield return new WaitForSeconds(2);
            isShooting = false;
        } else {
            lr.enabled = false;
            yield return new WaitForSeconds(2);
            isShooting = true;
        }
    }
}
