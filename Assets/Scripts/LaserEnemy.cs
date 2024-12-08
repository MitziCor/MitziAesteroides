using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 500f;
    public int hits = 1;
    public GameObject explosion;
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(force, 0));
        Debug.Log(" ");
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
     if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.hurt(15);
           // Destroy(collision.gameObject); //destruye el objeto con el que choca
            Destroy(gameObject);//destruye el laser
        }
    }
}
