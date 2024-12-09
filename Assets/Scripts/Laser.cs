using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 500f;
    GameController Gcl;

    /// <summary>
    /// Inicializa el comportamiento del l�ser al ser instanciado.
    /// Establece acceso al controlador del juego y aplica una fuerza inicial al l�ser para moverlo.
    /// </summary>
    /// <remarks>
    /// Obtiene el componente `GameController` desde el objeto etiquetado como "GameController" y configura el Rigidbody2D para aplicar movimiento.
    /// </remarks>
    void Start()
    {
        GameObject GclObj = GameObject.FindGameObjectWithTag("GameController"); //Tener abseso al controller desde unity
        Gcl = GclObj.GetComponent<GameController>();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(force, 0)); 
    }

    /// <summary>
    /// M�todo llamado una vez por frame para verificar si el l�ser ha salido del l�mite del juego.
    /// Si el l�ser excede el l�mite en el eje X, se destruye autom�ticamente.
    /// </summary>
    /// <remarks>
    /// Previene que objetos fuera de los l�mites permanezcan en la escena y consuman recursos.
    /// </remarks>
    void Update()
    {
        if (transform.position.x > 15f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// M�todo llamado cuando el l�ser colisiona con otro objeto.
    /// Si colisiona con un enemigo, incrementa la puntuaci�n del juego, destruye al enemigo y al propio l�ser.
    /// </summary>
    /// <param name="collision">El objeto con el que colisiona el l�ser.</param>
    /// <remarks>
    /// Maneja la interacci�n del l�ser con enemigos, otorgando puntos y limpiando los objetos destruidos de la escena.
    /// </remarks>
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
