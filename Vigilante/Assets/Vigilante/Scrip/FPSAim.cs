using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAim : MonoBehaviour
{
    public float mouseX;//declare flotante para mause en el vector x
    public float mouseY;//declare flotante para mause en el vector y
    public float secibility = 50f;//flotante para la sencibilidad
    public bool ShowCursor;//boleano para el cursor
    //public FPSMove fPSMove;
    public bool InvertedMouse;
    // Update is called once per frame
    void Update()
    {
        MovMause();
    }
    //inicia la accin del cursor
    void MovMause()
    {
        Camera cam = Camera.main;
        //seguir el cursor en x positivo
        mouseX += (Input.GetAxis("Mouse X") * secibility) * Time.deltaTime;
        mouseY -= (Input.GetAxis("Mouse Y") * secibility) * Time.deltaTime;
        //if para que al dar clic derecho mover la camara
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.eulerAngles = new Vector3(0, mouseX, 0);//para mover todoe el personaje con la camara en x
            cam.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);//para mover solo la camara en y
            Cursor.lockState = CursorLockMode.Locked;//cursosr se bloquean en el centro de la pantalla
            Cursor.visible = false;
        }
        else//si no hace clic derecho 
        {
            Cursor.lockState = CursorLockMode.None;//el cursosr deja de estar bloqueado
            Cursor.visible = true;
        }
    }
}