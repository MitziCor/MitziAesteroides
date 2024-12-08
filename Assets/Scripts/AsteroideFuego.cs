
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideFuego : MonoBehaviour
{
    public float force = -500f;
    public float fire = 1f;
    int contador = 5;
    Player p;

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

        //Destroy(gameObject, 10);
    }

    void Update()
    {
        //manera de destruir los clones del asteroid
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            contador = 5;
            p = col.GetComponent<Player>();
            StartCoroutine(Fire_Damage());
        }

    }
    IEnumerator Fire_Damage()
    {
        Renderer r = GetComponent<Renderer>();
        r.enabled = false;
        Collider2D c = GetComponent<Collider2D>();
        c.enabled = false;
        while (contador > 0)
        {
            Debug.Log(contador);
            Debug.Log("Choco con player");
            p.hurt(3);
            contador--;
            yield return new WaitForSeconds(fire);
        }
    }


}

