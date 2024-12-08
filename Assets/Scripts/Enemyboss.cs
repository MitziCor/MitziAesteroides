using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyboss : MonoBehaviour
{

    float direccion = 1;
    public GameObject laser;
    void Start()
    {
        StartCoroutine(SpawnLaserEnemi());

    }
    void Update()
    {
        //Forma de detenerse y cambiar de movimiento (de arriba hacia abajo)
        Vector3 pos =transform.position;
        if(pos.x > 6)
        {
            pos.x -= Time.deltaTime * 3.0f;
        }
        else
        {
            if(direccion ==1 && pos.y >= 4)
            {
                direccion=-1;
                pos.y = 4;
            }
            else if (direccion ==-1 && pos.y <= -4){ //1 es direccion hacia arriva y -1 es direccion hacia abajo
                direccion=1;
                pos.y = -4;
            }
        pos.y += Time.deltaTime * 3.0f * direccion;
        }
        transform.position = pos;

    }
    IEnumerator SpawnLaserEnemi()
    {
        yield return new WaitForSeconds(3.0f);
        while(true)
        {
            yield return new WaitForSeconds(1.5f);
                Instantiate(laser, transform.position, Quaternion.identity);    
        }
    }
}
