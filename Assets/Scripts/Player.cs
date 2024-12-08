using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 3f;
    public float hp = 100;
    public GameObject laser;
    bool toxic1=false;

    float firerate = 1f;
    float fireRateDelta = 0;
    public float tiempo = 5f;
    public GameObject boomerang;
    public GameObject explosivo;
   

    Rigidbody2D rb; //llamar al componente rigibody
    
    void Start() //Este metodo
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(new Vector2(500, 0)); //PRIMERA PRESENTACION O TAMBIEN PUEDE SER: Vector2 force = new Vector2(500,0) 500 es fuerza en X y 0 es una fuerza en Y
        StartCoroutine(Veneno());
    }

    // Update is called once per frame
    void Update() //Habla de frames (fotogramas), funciona a 30
    {
        move();
        fire();
        fireboomerang();
       explosivo1();
    }
    void fire()
    {
        fireRateDelta += Time.deltaTime; //Esto es para que despues de 0.5f (medio segundo) te deje disparar
        if (fireRateDelta > firerate)
        {
            //otra manera de get.axis
            if (Input.GetKeyDown(KeyCode.Space))//El getkey solo se llama cada que se preciona, el KeyCode.Space significa que va a ser la tecla de espacio en el teclado
            {
                Instantiate(laser, transform.position, Quaternion.identity); //Instantiate: Para duplicar un objeto en particular Quaternion.identity : 
                fireRateDelta = 0;  
            }
        }
        

    }
    void move()
    {
        float inputX = Input.GetAxis("Horizontal"); //Metodo para mover jugador de manera horinzontal, tinen que ser igual de escritos, es un valora entre1 y -1
        float inputY = Input.GetAxis("Vertical"); //Metodo para mover aol jugador de manera vertical

        //Primera manera de desplazar

        //Vector3 posicion = transform.position; //Vector3 es una clase que viene de unity, transform es un componenete que tiene Unity y position es una unidad de transform
        //posicion.x = posicion.x + inputX * Time.deltaTime * velocidad; //Time.deltaTime * inputX significa que por cada segundo se mueve una unidad, cuadno se multiplica por velocidad significa que se va a mover otra cantidad de unidades por segundo
        //posicion.y = posicion.y + inputY * Time.deltaTime * velocidad;
        //transform.position = posicion;

        rb.AddForce(new Vector2(20 * inputX, 20 * inputY)); //es una aceleracion ya que el Force empuja en x cada fotograma
        //En x
        Vector2 rbVel = rb.velocity;
        if (rb.velocity.x > velocidad) //esto es para mantener una misma velocidad
        {
            rbVel.x = velocidad;
            rb.velocity = rbVel;
        }
        if (rb.velocity.x < -velocidad)
        {
            rbVel.x = -velocidad;
            rb.velocity = rbVel;
        }

        //En y

        if (rb.velocity.y > velocidad) //esto es para mantener una misma velocidad
        {
            rbVel.y = velocidad;
        }
        if (rb.velocity.y < -velocidad)
        {
            rbVel.y = -velocidad;
        }
        if (inputX == 0)
        {
            rbVel.x = 0;
        }
        rb.velocity = rbVel;
        if (inputY == 0)
        {
            rbVel.y = 0;
        }
        rb.velocity = rbVel;
    }
    
    public void hurt(int damage)
    {
        hp -= damage;
      if(hp <= 0)
        {
            hp = 0;

            GameObject GamecontrollerOBJ = GameObject.FindGameObjectWithTag("GameController");//Encontrar el objeto "____"
            if (GamecontrollerOBJ != null)
            {
                GameController gc = GamecontrollerOBJ.GetComponent<GameController>(); //Extarer el componente
                gc.lose();
            }
            Destroy(gameObject);
        }
    }
   IEnumerator Veneno()
    {
        while (true)
        {
            if(toxic1 == true)
            {
                hurt(3);
                
            }
           yield return new WaitForSeconds(tiempo);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Toxica")
        {
            toxic1 = true;
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Toxica")
        {
            toxic1 = false;
        }
    }
    void fireboomerang()
    {
        fireRateDelta += Time.deltaTime; //Esto es para que despues de 0.5f (medio segundo) te deje disparar
        if (fireRateDelta > firerate)
        {
            //otra manera de get.axis
            if (Input.GetKeyDown(KeyCode.E))//El getkey solo se llama cada que se preciona, el KeyCode.Space significa que va a ser la tecla de espacio en el teclado
            {
                boomerang boomerang1 = new boomerang();
                boomerang1.volver = 0;
                boomerang1.v = false;
                Instantiate(boomerang, transform.position, Quaternion.identity); //Instantiate: Para duplicar un objeto en particular Quaternion.identity : 
                
            }
        }
    }
    void explosivo1()
    {
        fireRateDelta += Time.deltaTime; //Esto es para que despues de 0.5f (medio segundo) te deje disparar
        if (fireRateDelta > firerate)
        {
            //otra manera de get.axis
            if (Input.GetKey(KeyCode.Q))//El getkey solo se llama cada que se preciona, el KeyCode.Space significa que va a ser la tecla de espacio en el teclado
            {
                Instantiate(explosivo, transform.position, Quaternion.identity); //Instantiate: Para duplicar un objeto en particular Quaternion.identity : 
                fireRateDelta = 0;
            }
        }
    }
    
}
