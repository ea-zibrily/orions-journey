using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lava : MonoBehaviour
{
    public Transform endPosition;
    public Transform lavaPos;
    public float moveSpeed;


    void Start()
    {
        if (lavaPos.position.y >= endPosition.position.y)
        {
            transform.position = new Vector2(transform.position.x, endPosition.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, lavaPos.position.y);
        }
        this.enabled = false;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(transform.position.x, endPosition.position.y),
            moveSpeed * Time.fixedDeltaTime);
    }

    public void CutScene(){
        transform.position = new Vector2(transform.position.x, endPosition.position.y - 3f);
    }

}
