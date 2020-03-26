using UnityEngine;
using System.Collections;

public class golpeArmaBlanca : MonoBehaviour {

    public int golpeandoArmaBlanca=0;
    public int desactivando = 1;

    public void activandoDañoArmaBlanca()
    {
        Debug.Log("Activa");
        desactivando = 1;
        golpeandoArmaBlanca = 1;
    }
    public void desactivandoDañoArmaBlanca()
    {
        Debug.Log("DesActiva");
        desactivando = 0;
        golpeandoArmaBlanca = 0;
    }
}
