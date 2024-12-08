using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 500f;
    GameController Gcl;
    void Start()
    {
        GameObject GclObj = GameObject.FindGameObjectWithTag("GameController"); //Tener abseso al controller desde unity
        Gcl = GclObj.GetComponent<GameController>();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(force, 0)); 
    }
    void Update()
    {
        if (transform.position.x > 15f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
     if(collision.tag == "Enemy")
        {
            Gcl.incrementScore(3);

            Destroy(collision.gameObject); //destruye el objeto con el que choca
            Destroy(gameObject);//destruye el laser
        }
    }
}
