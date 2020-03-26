using UnityEngine;
using System.Collections;
using sharptest;

public class Movimiento : MonoBehaviour {

    public Vector3 moveDirection = Vector3.zero;
    public Transform myTransform;
    CharacterController controller;
    public CollisionFlags collisionFlags;

    public float velocidadMovimiento = 10f;
    public float GetaxH;
    public float GetaxV;
    private float gravedad = 120;
    // Use this for initialization
    void Start () {
        myTransform = transform;
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        //Declaramos variables para saber en que direccion se movera el jugador de acuerdo al Input de Unity
        GetaxH = Input.GetAxis("Horizontal");
        GetaxV = Input.GetAxis("Vertical");

        if (controller.isGrounded)//Si el personaje esta haciendo colision con el suelo
        {
            
            if (Mathf.Abs(GetaxH) > .2)//Si el usuario Rota hacia la izquierda o derecha a el personaje
            {
                //Se llama una funcion para rotar a el personaje ((PROGRAMACION FUNCIONAL))  1
                myTransform.Rotate(0,(float)MovimientoZ.rotando(GetaxH,Time.deltaTime,170), 0);
            }
            if ( Mathf.Abs(GetaxV) > .2f)//Si el usuario Mueve hacia adelante o atras a el personaje
            {
                moveDirection = new Vector3(0, 0, (GetaxV));
                moveDirection = myTransform.TransformDirection(moveDirection).normalized;
                moveDirection *= velocidadMovimiento;//Movemos al personaje con una velocidad establecida previamente
            }

            if (Mathf.Abs(GetaxH) < .2f && Mathf.Abs(GetaxH) > -.2f && Mathf.Abs(GetaxV) < .2f && Mathf.Abs(GetaxV) > -.2f)//Si el usuario no preciona ninguna direccion
                moveDirection = new Vector3(0, 0, 0);//El personaje no se mueve
        }
        //Se llama una funcion para aplicar la gravedad a el personaje((PROGRAMACION FUNCIONAL))  2
        moveDirection.y = (float)Gravedad.calculandoGravedad(moveDirection.y, gravedad, Time.deltaTime);
        collisionFlags = controller.Move(moveDirection * Time.deltaTime);
        
    }
}
