using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onda : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosion;

    void Start()
    {
        Destroy(gameObject, 1);
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Player");
        if (col.tag == "Enemy")
        {
            Debug.Log("choco con asteroide");
            Destroy(col.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            //Destroy(gameObject);

        }
    }

}
