using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sharptest;


public class RecibiendoDañoPlayer : MonoBehaviour
{
    private int bloq = 0;
    private int bloq2 = 0;
    public float vida;
    public float tiempo=0;
    Transform enemigo;
    EstadisticasPlayer estadisticas;
    Equipamiento equipo;
    Movimiento movimient;
    // Use this for initialization
    void Start()
    {
        vida = 100;
        estadisticas = transform.parent.GetComponent<EstadisticasPlayer>();
        equipo = transform.parent.GetComponent<Equipamiento>();
        movimient = transform.parent.GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            bloq = 0;
            bloq2 = 0;
        }

        if (estadisticas.miedo <= 0)
            movimient.velocidadMovimiento = 10;
        
        if (movimient.velocidadMovimiento < 0)
            movimient.velocidadMovimiento = 0;

        if (vida < 0)
            vida = 0;
        tiempo += Time.deltaTime;
        if(tiempo>=4)
        {
            vida = (float)Suma.fsum(vida, 0.1f);//Se aumenta la vida del personaje despues de 4 segundos con una funcion ((PROGRAMACION FUNCIONAL))  4
        }
        if (vida >= 100)
            tiempo = 0;

    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("tagEnemigo"))
        {
            Debug.Log("ALGO Tagherir");
            if (bloq == 0)
            {
                //Llamando a una funcion, se aumenta el MIEDO del personaje cuando lo toque un enemigo((PROGRAMACION FUNCIONAL)) 4
                estadisticas.miedo = (float)Suma.fsum(estadisticas.miedo, 30);
                /*Se disminuye la velocidad en la que se mueve el personaje llamando una funcion para que multiplique y reste velocidad. Dependiendo 
                del MIEDO del personaje bajara aun mas ////////////////////////((PROGRAMACION FUNCIONAL))  5*/
                movimient.velocidadMovimiento = movimient.velocidadMovimiento - ((float)Multiplicacion.fmul(estadisticas.miedo, 0.1));
                
                bloq = 1;
            }
        }
        if(other.CompareTag("tagDaño"))
        { 
            if(bloq == 0)
            {
                tiempo = 0;
                if (estadisticas.miedo <= 0)
                    vida = (float)Resta.fres(vida, 20);//Llamando a una funcion, se le resta vida a el Personaje ((PROGRAMACION FUNCIONAL))  6
                else
                {
                    //Llamando a una funcion, Se le resta vida al personaje dependiendo si tiene MIEDO se le restara aun MAS ((PROGRAMACION FUNCIONAL))  7
                    vida = (float)Resta.fres(vida, VulnerabilidadMiedo.bajandoVidaMiedo(estadisticas.miedo, 20));
                }
                bloq = 1;
            }
        }
        if (other.CompareTag("tagMaderaClavos"))
        {
            equipo.AgregandoObjeto("01");
            Destroy(other.transform.gameObject);
        }
    }
}
