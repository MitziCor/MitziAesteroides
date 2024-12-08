using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerang : MonoBehaviour
{
    public GameObject explosion;
    Rigidbody2D rb;
    public float force = 1f;
    public float regresar = 10f;
    public float volver;
    public bool v;
    void Start()
    {
        volver = 0;
        v = false;
    }
    void Update()
    {
        float viajo = Time.deltaTime * force;
        if (!v)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(force, 0));
            volver += viajo;
            v = (transform.position.x > regresar);
            Debug.Log((transform.position.x > regresar));
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(-force, 0));
            volver -= viajo;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("choco con asteroide");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            //Destroy(gameObject);
        }
    }
}
