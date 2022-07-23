using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBilly : MonoBehaviour
{
    private float randomSpawn;

    public float nilaiXKiri;
    public float nilaiXKanan;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawn = Random.Range(nilaiXKiri, nilaiXKanan);
        transform.position = new Vector2(randomSpawn, transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.down * 100f, moveSpeed * Time.fixedDeltaTime); 
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Destroyer"){
            Destroy(gameObject);
        }
        if(other.CompareTag("Player")){
            other.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.gameObject.transform.SetParent(null);
        }
    }
}
