using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserStartAnim : MonoBehaviour
{
    private bool isShooting;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot(){
        if(isShooting == true){
            anim.SetBool("isShooting", true);

            yield return new WaitForSeconds(2);
            isShooting = false;
        } else {
            anim.SetBool("isShooting", false);
            yield return new WaitForSeconds(2);
            isShooting = true;
        }
    }
}
