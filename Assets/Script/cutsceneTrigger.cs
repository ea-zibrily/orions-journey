using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutsceneTrigger : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<PlayableDirector>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("cutscene"))
        {
            gameObject.GetComponent<PlayableDirector>().enabled = true;
        }
    }
}
