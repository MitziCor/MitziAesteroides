
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideToxico : MonoBehaviour
{
    public float force = -500f;
    public GameObject venomzone;

    Rigidbody2D rb;
    GameController Gcl;
    void Start()
    {
        GameObject GclObj = GameObject.FindGameObjectWithTag("GameController");
        Gcl = GclObj.GetComponent<GameController>();

        Vector3 pos = transform.position;
        pos.y = Random.Range(-5, 5);
        transform.position = pos;

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(force, 0));

        Destroy(gameObject, 10);
    }

    void Update()
    {
        if (transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Laser" || col.tag == "Player")
        {
            Instantiate(venomzone, transform.position, Quaternion.identity);
        }
    }

}