using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaManager : MonoBehaviour
{
    [Header("Lava Checkpoint")]
    [SerializeField] public string lavacheck = "Gas Dek";
    [SerializeField] public static Vector2 lastCheckpointPosLava = new Vector2(0.4f, -9.3f);
   
    private void Awake()
    {
        Debug.Log(lavacheck);
        GameObject.FindGameObjectWithTag("lava").transform.position = lastCheckpointPosLava;
    }

}
