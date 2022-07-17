using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaCheckpoint : MonoBehaviour
{
    public checkPoint playerCheck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("lava") && playerCheck.isCheck)
        {
            Debug.Log("Lava Check!");
            lavaManager.lastCheckpointPosLava = transform.position;
        }
    }
}
