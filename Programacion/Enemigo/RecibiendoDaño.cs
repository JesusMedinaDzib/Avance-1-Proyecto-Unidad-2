using UnityEngine;
using System.Collections;
using sharptest;

public class RecibiendoDaño : MonoBehaviour {
    public double vida;
    private int bloq = 0;
    Transform player;
	// Use this for initialization
	void Start () {
        vida = 100;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (player != null)
        {
            if (player.GetComponent<golpeArmaBlanca>().desactivando == 0)
                bloq = 0;
        }

        if(vida<=0)
        {
            GameObject.FindGameObjectWithTag("tagPlayer").GetComponent<EstadisticasPlayer>().enemigosMuertos++;
            Destroy(transform.parent.gameObject);
        }
	}
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("tagArmaBlanca"))
        {
            Debug.Log("ALGO");
            if (other.transform.GetComponent<golpeArmaBlanca>().golpeandoArmaBlanca == 1 && bloq == 0)
            {
                player = other.transform;

                if(other.transform.root.GetComponent<EstadisticasPlayer>().miedo<=0)
                    vida = Resta.fres(vida, 40);////////////////////////////////////////////FUNCIONAL
                else 
                {
                    //Llamando a una funcion, se le resta MENOS vida a el Enemigo dependiendo de el MIEDO del Personaje ((PROGRAMACION FUNCIONAL))  10
                    vida = Resta.fres(vida, GolpeMiedo.calculandoDanio(other.transform.root.GetComponent<EstadisticasPlayer>().miedo, 40));
                }
                bloq = 1;
            }
        }
        
    }
}
