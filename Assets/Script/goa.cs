using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goa : MonoBehaviour
{
    public void closeGoa()
    {
        transform.position = new Vector2(13.18f, 4.9255f);
    }
    public void openGoa()
    {
        transform.position = new Vector2(13.18f, 8.77f); 
    }
}
