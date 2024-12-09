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

    /// <summary>
    /// Inicializa el componente Rigidbody2D y comienza el efecto del veneno si es necesario.
    /// </summary>
    void Start() //Este metodo
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(new Vector2(500, 0)); //PRIMERA PRESENTACION O TAMBIEN PUEDE SER: Vector2 force = new Vector2(500,0) 500 es fuerza en X y 0 es una fuerza en Y
        StartCoroutine(Veneno());
    }

    /// <summary>
    /// Actualiza el estado del jugador en cada fotograma, gestionando movimiento y disparos.
    /// </summary>
    void Update() //Habla de frames (fotogramas), funciona a 30
    {
        move();
        fire();
        fireboomerang();
       explosivo1();
    }

    /// <summary>
    /// Dispara un láser desde la posición del jugador si se presiona la tecla espacio y el intervalo de disparo lo permite.
    /// </summary>
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

    /// <summary>
    /// Gestiona el movimiento del jugador con aceleración controlada y velocidad máxima.
    /// </summary>
    void move()
    {
        float inputX = Input.GetAxis("Horizontal"); 
        float inputY = Input.GetAxis("Vertical"); 
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

    /// <summary>
    /// Reduce la salud del jugador cuando recibe daño.
    /// Si la salud llega a cero, destruye al jugador y activa la condición de derrota en el GameController.
    /// </summary>
    /// <param name="damage">Cantidad de daño a aplicar.</param>
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

    /// <summary>
    /// Aplica daño periódico al jugador si está en contacto con un objeto tóxico.
    /// </summary>
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

    /// <summary>
    /// Detecta si el jugador entra en contacto con objetos tóxicos.
    /// </summary>
    /// <param name="collision">El objeto con el que colisiona el jugador.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Toxica")
        {
            toxic1 = true;
        }
    }

    /// <summary>
    /// Detecta si el jugador  sale del area de contacto con objetos tóxicos.
    /// </summary>
    /// <param name="collision">El objeto con el que colisiona el jugador.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Toxica")
        {
            toxic1 = false;
        }
    }

    /// <summary>
    /// Lanza un boomerang si se presiona la tecla 'E'.
    /// </summary>
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

    /// <summary>
    /// Lanza un explosivo si se mantiene presionada la tecla 'Q'.
    /// </summary>
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
