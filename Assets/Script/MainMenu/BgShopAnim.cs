using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgShopAnim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void Shop(){
        anim.SetTrigger("OpenShop");
    }

    public void Back(){
        anim.SetTrigger("CloseShop");
    }

}
