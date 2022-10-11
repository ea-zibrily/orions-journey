using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skretchryArrow : MonoBehaviour
{
    public float speed;
    Transform player;
    Vector2 target;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if((transform.position.x == target.x) && (transform.position.y == target.y))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
