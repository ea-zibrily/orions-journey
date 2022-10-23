using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [Header("Between Limit")]
    public float gressLimit;
    public float skretchLimit;
    public float pursLimit;

    [Header("Boss manah?")]
    public bool isGress;
    public bool isSkretch;

    [Header("Reference")]
    public GameObject gressObject;
    public GameObject skretchObject;
    public GameObject pursObject;
    public boss3CC cutScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bossSpawnerCoroutine());
    }

    IEnumerator bossSpawnerCoroutine()
    {
        if(isGress && !isSkretch)
        {
            yield return new WaitForSeconds(gressLimit);
            Instantiate(gressObject, transform.position, Quaternion.identity);
            StartCoroutine(bossSpawnerCoroutine());
        }
        if(isSkretch && !isGress)
        {
            yield return new WaitForSeconds(skretchLimit);
            Instantiate(skretchObject, transform.position, Quaternion.identity);
            StartCoroutine(bossSpawnerCoroutine());
        }
        if (!isGress && !isSkretch)
        {
            yield return new WaitForSeconds(pursLimit);
            Instantiate(pursObject, transform.position, Quaternion.identity);
            StartCoroutine(bossSpawnerCoroutine());
        }
    }
}
