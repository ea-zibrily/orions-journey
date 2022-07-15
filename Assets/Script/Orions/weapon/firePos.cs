using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePos : MonoBehaviour
{
 [SerializeField] float rotateSpeed;

    void Update(){
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, 8) - 4);
    }
}
