using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosivo : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 500f;
    public GameObject explosion;
    public GameObject onda;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(force, 0));

        Destroy(gameObject, 3);
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
            Instantiate(onda, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
