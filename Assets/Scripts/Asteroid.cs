 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //Comentario prueba
    //Bruh
    public GameObject explosion;
    public float force = -500f; //fuerza
    public int hp = 100;
    Rigidbody2D rb;

    /// <summary>
    /// Método llamado al iniciar el juego o cuando el objeto es activado. 
    /// Posiciona aleatoriamente el asteroide en el rango de -5 a 5 en el eje Y y aplica una fuerza a la dirección X.
    /// </summary>
    /// <remarks>
    /// Este método también obtiene el componente `Rigidbody2D` para aplicar la física del asteroide.
    /// </remarks>
    void Start()
    {

        Vector3 pos = transform.position; //El vector se transformo en posicion
        pos.y = Random.Range(-5, 5);
        transform.position = pos;

        
        rb = GetComponent<Rigidbody2D>(); 
        rb.AddForce(new Vector2(force, 0));
    }

    /// <summary>
    /// Método llamado una vez por frame para comprobar si el asteroide ha salido de los límites del juego.
    /// Si el asteroide ha cruzado el límite en el eje X, se destruye.
    /// </summary>
    /// <remarks>
    /// Este método se asegura de que los asteroides que se alejan del área de juego sean destruidos.
    /// </remarks>
    void Update()
    {
        //manera de destruir los clones del asteroid
     if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }   
    }

    /// <summary>
    /// Método llamado cuando el asteroide entra en contacto con otro collider.
    /// Si el asteroide colisiona con la nave del jugador, reduce su salud y realiza daño al jugador.
    /// </summary>
    /// <param name="collision">El collider con el que el asteroide entra en contacto.</param>
    /// <remarks>
    /// Este método detecta la colisión entre el asteroide y el jugador, causando daño al jugador y al propio asteroide.
    /// </remarks>
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

    /// <summary>
    /// Reduce la salud del asteroide cuando recibe daño. Si la salud llega a cero, el asteroide es destruido.
    /// </summary>
    /// <param name="damage">La cantidad de daño que recibe el asteroide.</param>
    /// <remarks>
    /// Si la salud del asteroide es reducida a cero, se instancia una explosión en su lugar y se destruye el objeto.
    /// </remarks>
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
