using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxDestory : MonoBehaviour
{
    public ParticleSystem _Destroy;

    void OnDestroy(){
        Instantiate(_Destroy, transform.position, Quaternion.identity);
    }
}
