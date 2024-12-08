using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Boss : MonoBehaviour
{
    
    public GameObject Espada;

    void Start()
    {
        StartCoroutine(SpawnEspadaEnemi());
    }
    
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x > 6)
        {
            pos.x -= Time.deltaTime * 3.0f;
        }
        
        transform.position = pos;
    }
    IEnumerator SpawnEspadaEnemi()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Instantiate(Espada, transform.position, Quaternion.identity);
        }
    }

}
