 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public float force = -500f;
    public int hp = 100;
    Rigidbody2D rb;
    void Start()
    {

        Vector3 pos = transform.position; //El vector se transformo en posicion
        pos.y = Random.Range(-5, 5); //Este codigo hace que se posicione en cualquier lugar dentro del rango
        transform.position = pos;

        
        rb = GetComponent<Rigidbody2D>();   //
        rb.AddForce(new Vector2(force, 0)); //AddForce es la fuerza que se da en x y en Y

       // Destroy(gameObject, 10); //Se van a destruir despues de unos 10 seg
    }

   
    void Update()
    {
        //manera de destruir los clones del asteroid
     if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }   
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Choco con Player");
           // Destroy(collision.gameObject);//acceder al objeto con el que estamos chocando

            Player player = collision.GetComponent<Player>();
            player.hurt(15);

            hurt(100);
        }
        
    }
    public void hurt(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
