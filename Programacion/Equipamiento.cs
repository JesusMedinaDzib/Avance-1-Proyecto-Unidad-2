using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using sharptest;

public class Equipamiento : Animaciones {

    public GameObject armaBlanca;
    List<string> equipamiento = new List<string>();
    // Use this for initialization
    int q=0;
    void Start () {
        armaBlanca.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown("e"))
        {
            Debug.Log(equipamiento[0]);
        }
        if (Input.GetKeyDown("r"))
        {
            ListaEquipamiento.limpiar();
        }


    }
    public void AgregandoObjeto(string objetoId)
    {
        armaBlanca.SetActive(true);
        ListaEquipamiento.agregar(objetoId);//Se llama una funcion para agregar las armas a el inventario del personaje((PROGRAMACION FUNCIONAL))  3
        equipamiento = ListaEquipamiento.booksList;
    }
}
