using UnityEngine;
using System.Collections;

public class Animaciones : MonoBehaviour {

    // Use this for initialization
    Animator controlAnimator;
    Equipamiento equipar;
    golpeArmaBlanca objArmaBlanca;

    public float GetaxH;
    public float GetaxV;
    private int bloq=0;

    public int pasandoGolpeBasico =0;


    void Start () {
        controlAnimator = GetComponent<Animator>();
        equipar = GetComponent<Equipamiento>();

    }
	
	// Update is called once per frame
	void Update () {
        GetaxH = Input.GetAxis("Horizontal");
        GetaxV = Input.GetAxis("Vertical");

        if (pasandoGolpeBasico==0)
        {
            if (Mathf.Abs(GetaxH) > .2f)
            {
                caminando();
            }

            if (Mathf.Abs(GetaxV) > .2f)
            {
                caminando();
            }

            if (Mathf.Abs(GetaxH) < .2f && Mathf.Abs(GetaxH) > -.2f && Mathf.Abs(GetaxV) < .2f && Mathf.Abs(GetaxV) > -.2f)
            {
                //if(controlAnimator.GetBool("golpear")== false)
                parado();
            }
        }
        //if(Input.GetButtonDown("boton X"))
        if (Input.GetKeyDown("space"))
        {
            if (equipar.armaBlanca != null)
            {
                objArmaBlanca = equipar.armaBlanca.GetComponent<golpeArmaBlanca>();
                golpeando();
            }
        }
    }

    public void parado()
    {
        controlAnimator.SetBool("caminar", false);
        controlAnimator.ResetTrigger("golpear");
        controlAnimator.SetBool("parado", true);
    }

    public void caminando()
    {
        controlAnimator.SetBool("parado", false);
        controlAnimator.ResetTrigger("golpear");
        controlAnimator.SetBool("caminar", true);
    }

    public void golpeando()
    {
        controlAnimator.SetBool("caminar", false);
        controlAnimator.SetBool("parado", false);
        controlAnimator.SetTrigger("golpear");
    }

    public void golpeandoInicio()
    {
        pasandoGolpeBasico = 1;
    }
    public void golpeandoFinal()
    {
        pasandoGolpeBasico = 0;
    }

    public void golpeandoInicioDaño()
    {
        if (objArmaBlanca != null)
            objArmaBlanca.activandoDañoArmaBlanca();
    }
    public void golpeandoFinalDaño()
    {
        if (objArmaBlanca != null)
            objArmaBlanca.desactivandoDañoArmaBlanca();
    }
}
