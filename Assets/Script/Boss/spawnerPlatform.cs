using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerPlatform : MonoBehaviour
{
    public GameObject spawner;
    public float timerSpawner;
    private float time;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(time <= 0){
            Instantiate(spawner, transform.position, Quaternion.identity);
            time = timerSpawner;
        } else {
            time -= Time.fixedDeltaTime;
        }
    }
}
