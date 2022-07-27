using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goatrigger : MonoBehaviour
{
    public goa goaDoor;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            goaDoor.closeGoa();
        }
    }
}
