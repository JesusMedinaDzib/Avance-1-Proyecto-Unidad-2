using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using sharptest;

public class EstadisticasPlayer : MonoBehaviour
{
    private Image barraMiedo;
    public float miedo;
    public float tiempo;
    public double enemigosMuertos;
    // Start is called before the first frame update
    void Start()
    {
        enemigosMuertos = 0;
        miedo = 0;
        barraMiedo = GameObject.FindGameObjectWithTag("tagCanvas").transform.GetChild(0).GetChild(1).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    { 
        
        tiempo += Time.deltaTime;
        if (miedo > 0)
        {
            /*Llamando a una funcion, se aumentara la velocidad en el que el personaje deje de tener MIEDO dependiendo de
             cuantos enemigos haya matado hasta ahora  ///////////////// ((PROGRAMACION FUNCIONAL))  8*/
            miedo = (float)Resta.fres(miedo,BajandoMiedo.bajandoMiedo(enemigosMuertos));
            //Debug.Log( BajandoMiedo.bajandoMiedo(enemigosMuertos));
        }
        else
            tiempo = 0;

        miedo = Mathf.Clamp(miedo, 0, 100);
        //Llamando una funcion se realizara una division para ajustar la barra de medicion de MIEDO en la Interfaz ((PROGRAMACION FUNCIONAL))  9
        barraMiedo.fillAmount = (float)Division.fdiv(miedo,100);
    }
}
