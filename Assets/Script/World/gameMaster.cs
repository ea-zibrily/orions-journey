using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour
{
    private static gameMaster instance;
    public Vector2 localCheckpointPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
