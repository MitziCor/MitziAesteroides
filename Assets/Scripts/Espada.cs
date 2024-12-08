using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaBoss : MonoBehaviour
{
    GameController Gcl;
    Rigidbody2D rb;
    public float force = -500f;
   
    void Start()
    {
        GameObject GclObj = GameObject.FindGameObjectWithTag("GameController"); 
        Gcl = GclObj.GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(force, 0));
    }

    
    void Update()
    {
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Gcl.incrementScore(-3);
            Player player = collision.GetComponent<Player>();
            player.hurt(30);
            
            Destroy(gameObject);
        }
    }
}
